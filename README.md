# DariuszLabaj.MaterialIo461

This library is based on Material Design 3.0 principles, providing developers with a modern and intuitive design framework for building user interfaces.
>**Note** that the Path icons used within this library are conversions sourced from [Google Fonts Icons](https://fonts.google.com/icons).
These converted icons are used for convenience, and I do not claim any rights to the original designs.

## Themes

You can easily create custom color themes based on Material IO themes using this website: [Material Theme to Xaml](https://dariuszlabaj.github.io/MaterialThemeToXaml/)

## Source of Icons

The icons used in this repository are sourced and converted from Google Fonts Icons. You can browse the original icon set [here](https://fonts.google.com/icons).

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Usage

To include the styles and resources in your project, merge the resource dictionary in your `App.xaml`:

```xaml
<ResourceDictionary Source="pack://application:,,,/MaterialIo;component/Resources.xaml"/>
```

To use the user controls in your XAML files, add the following namespace declaration:

```xaml
        xmlns:material="clr-namespace:DariuszLabaj.MaterialIo.UserControll;assembly=MaterialIo"
```
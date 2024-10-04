---
title: Obtener llamadas de advertencia para la sustitución de fuentes en Aspose.Slides
type: docs
weight: 120
url: /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides para .NET permite obtener llamadas de advertencia para la sustitución de fuentes en caso de que la fuente utilizada no esté disponible en la máquina durante el proceso de renderizado. Las llamadas de advertencia son útiles para depurar los problemas de fuentes faltantes o inaccesibles durante el proceso de renderizado.

{{% /alert %}} 
## **Obtener llamadas de advertencia para la sustitución de fuentes**
Aspose.Slides para .NET proporciona métodos API simples para obtener las llamadas de advertencia durante el proceso de renderizado. Todo lo que necesita hacer es seguir los pasos a continuación para configurar las llamadas de advertencia en su lado.:

1. Cree una clase de Callback personalizada para recibir las llamadas.
1. Establezca las llamadas de advertencia utilizando la clase LoadOptions.
1. Cargue el archivo de presentación que está utilizando una fuente para el texto que no está disponible en su máquina de destino.
1. Genere la miniatura de la diapositiva para ver el efecto.

```c#
//Configuración de llamadas de advertencia
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//Instanciar la presentación
Presentation presentation = new Presentation("1.ppt", lo);

//Generando miniatura de diapositiva
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "La fuente será sustituida de X a Y"
        return ReturnAction.Continue;
    }
}
```
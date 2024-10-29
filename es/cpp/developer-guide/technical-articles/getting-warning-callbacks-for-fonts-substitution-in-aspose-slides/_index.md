---
title: Obtención de Callbacks de Advertencia para la Sustitución de Fuentes en Aspose.Slides
type: docs
weight: 70
url: /es/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides para C++ hace posible obtener callbacks de advertencia para la sustitución de fuentes en caso de que la fuente utilizada no esté disponible en una máquina durante el proceso de renderizado. Los callbacks de advertencia son útiles al depurar problemas de fuentes que faltan o que son inaccesibles durante el proceso de renderizado.

{{% /alert %}} 
## **Obtención de Callbacks de Advertencia para la sustitución de fuentes**
Aspose.Slides para C++ proporciona métodos de API simples para obtener los Callbacks de Advertencia durante el proceso de renderizado. Solo necesitas seguir los pasos a continuación para configurar los Callbacks de Advertencia en tu lado:

1. Crea una clase Callback personalizada para recibir los callbacks.
1. Configura los Callbacks de Advertencia utilizando la clase [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options).
1. Carga el archivo de presentación que utiliza una fuente para el texto que está disponible en tu máquina de destino.
1. Genera la miniatura de la diapositiva para ver el efecto.

``` cpp
class HandleFontsWarnings : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
        {
            return Warnings::ReturnAction::Continue;
        }

        // 1 - WarningType.DataLoss
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));
        // "La fuente será sustituida de X a Y"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // Configuración de Callbacks de Advertencia
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // Instanciar la presentación
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // Generación de miniaturas de diapositivas
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```
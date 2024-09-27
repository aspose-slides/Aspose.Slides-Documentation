---
title: Получение обратных вызовов предупреждений для замены шрифтов в Aspose.Slides
type: docs
weight: 70
url: /ru/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides для C++ позволяет получать обратные вызовы предупреждений для замены шрифтов в случае, если используемый шрифт недоступен на машине в процессе рендеринга. Обратные вызовы предупреждений полезны при отладке проблем с отсутствующими или недоступными шрифтами в процессе рендеринга.

{{% /alert %}} 
## **Получение обратных вызовов предупреждений для замены шрифтов**
Aspose.Slides для C++ предоставляет простые методы API для получения обратных вызовов предупреждений в процессе рендеринга. Все, что вам нужно сделать, это следовать указанным ниже шагам для настройки обратных вызовов предупреждений на вашей стороне:

1. Создайте класс обратного вызова, чтобы получать обратные вызовы.
1. Установите обратные вызовы предупреждений с помощью класса [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options).
1. Загрузите файл презентации, который использует шрифт для текста, недоступный на вашей целевой машине.
1. Сгенерируйте миниатюры слайдов, чтобы увидеть эффект.

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
        // "Шрифт будет заменен с X на Y"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // Установка обратных вызовов предупреждений
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // Создание презентации
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // Генерация миниатюр слайдов
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```
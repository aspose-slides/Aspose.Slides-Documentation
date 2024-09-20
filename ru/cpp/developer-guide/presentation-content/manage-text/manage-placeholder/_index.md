---
title: Управление заполнительными текстами
type: docs
weight: 10
url: /cpp/manage-placeholder/
keywords: "Заполнитель, Заполнительный текст, Подсказка, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Изменение заполнителей текстов и текстов подсказок в презентациях PowerPoint на C++"
---

## **Изменить текст в заполнителе**
С помощью [Aspose.Slides для C++](/slides/cpp/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вам вносить изменения в текст заполнителя.

**Предварительное условие**: у вас должна быть презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как вы можете использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Переберите формы, чтобы найти заполнитель.
4. Приведите заполнитель к типу [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/), связанного с [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Сохраните измененную презентацию.

Этот код на C++ демонстрирует, как изменить текст в заполнителе:

```c++
// Путь к директории документов.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Получает доступ к первому слайду
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Получает доступ к первому и второму заполнителю на слайде и приводит его к AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"Это заполнитель");
	
// Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить текст подсказки в заполнителе**
Стандартные и предустановленные макеты содержат тексты подсказок заполнителей, такие как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставить свои предпочтительные тексты подсказок в макеты заполнителей.

Этот код на C++ показывает, как установить текст подсказки в заполнитель:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Когда в нем нет текста, PowerPoint отображает "Нажмите, чтобы добавить заголовок".
        {
            text = u"Нажмите, чтобы добавить заголовок";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // То же самое для подзаголовка.
        {
            text = u"Нажмите, чтобы добавить подзаголовок";
        }
        System::Console::WriteLine(u"Заполнитель: {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить прозрачность изображения заполнителя**

Aspose.Slides позволяет вам устанавливать прозрачность фона изображения в текстовом заполнителе. Регулируя прозрачность изображения в таком кадре, вы можете сделать текст или изображение более выразительными (в зависимости от цветов текста и изображения).

Этот код на C++ показывает, как установить прозрачность для изображения фона (внутри формы):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```
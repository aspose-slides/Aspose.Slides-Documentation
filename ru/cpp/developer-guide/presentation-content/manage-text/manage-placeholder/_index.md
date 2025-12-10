---
title: Управление заполнителями презентаций в C++
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/cpp/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- текст подсказки
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко управляйте заполнителями в Aspose.Slides для C++: заменяйте текст, настраивайте подсказки и устанавливайте прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполнителе**
Using [Aspose.Slides for C++](/slides/ru/cpp/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Требования**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) и передайте в него презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Пройдите по объектам Shape, чтобы найти заполнитель.
4. Приведите тип формы заполнителя к [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/), связанного с [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Сохраните изменённую презентацию.

This C++ code shows how to change the text in a placeholder:
```c++
// Путь к каталогу документов.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Загружает требуемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Получает первый и второй заполнитель на слайде и приводит его к AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установить текст подсказки в заполнителе**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This C++ code shows you how to set the prompt text in a placeholder:
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Когда в нём нет текста, PowerPoint отображает "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Делает то же самое для подзаголовка.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установить прозрачность изображения в заполнителе**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This C++ code shows you how to set the transparency for a picture background (inside a shape):
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


## **Часто задаваемые вопросы**

**Что такое базовый заполнитель и чем он отличается от локальной формы на слайде?**

Базовый заполнитель — это исходная форма на макете или мастере, от которой наследует форма слайда: тип, позиция и часть форматирования берутся из него. Локальная форма независима; если базового заполнителя нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без перебора каждого слайда?**

Отредактируйте соответствующий заполнитель на макете или мастере. Слайды, основанные на этих макетах/мастере, автоматически унаследуют изменения.

**Как управлять стандартными заполнителями верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом подвала?**

Используйте менеджеры HeaderFooter в соответствующем диапазоне (обычные слайды, макеты, мастер, заметки/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержимое.
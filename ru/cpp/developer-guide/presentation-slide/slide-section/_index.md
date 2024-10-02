---
title: Секция слайдов
type: docs
weight: 100
url: /ru/cpp/slide-section/
---

С помощью Aspose.Slides для C++ вы можете организовать презентацию PowerPoint на секции. Вы можете создать секции, которые содержат конкретные слайды.

Вы можете захотеть создать секции и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над крупной презентацией с другими людьми или командой — и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы имеете дело с презентацией, которая содержит много слайдов — и вам трудно управлять или редактировать ее содержимое одновременно.

Идеально, если вы создадите секцию, в которой содержатся схожие слайды — слайды имеют что-то общее или могут существовать в группе на основании правила — и дадите секции имя, которое описывает слайды внутри нее.

## Создание секций в презентациях

Чтобы добавить секцию, которая будет содержать слайды в презентации, Aspose.Slides для C++ предоставляет метод AddSection, который позволяет вам указать имя секции, которую вы собираетесь создать, и слайд, с которого начинается секция.

Этот образец кода показывает, как создать секцию в презентации на C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Секция 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Секция 2", newSlide3);
// секция1 завершится на newSlide2, и после нее начнется секция2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Последняя пустая секция");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## Изменение имен секций

После того как вы создали секцию в презентации PowerPoint, вы можете решить изменить ее имя.

Этот образец кода показывает, как изменить имя секции в презентации на C++ с использованием Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"Моя секция");
```
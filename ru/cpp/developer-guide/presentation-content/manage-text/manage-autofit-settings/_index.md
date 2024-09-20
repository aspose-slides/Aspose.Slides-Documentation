---
title: Управление настройками автоматической подгонки
type: docs
weight: 30
url: /cpp/manage-autofit-settings/
keywords: "Текстовое поле, Автоматическая подгонка, Презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Установите настройки автоматической подгонки для текстового поля в PowerPoint на C++"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер фигуры, чтобы поместить текст** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы гарантировать, что текст всегда помещается в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы оно могло вместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы убрать избыточное пространство. 

В PowerPoint есть 4 важных параметра или опции, которые контролируют поведение автоматической подгонки для текстового поля:

* **Не подвергать автоматической подгонке**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры, чтобы поместить текст**
* **Переносить текст в фигуре.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для C++ предоставляет аналогичные опции — некоторые методы в классе [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format), которые позволяют вам контролировать поведение автоматической подгонки для текстовых полей в презентациях.

## **Изменить размер фигуры, чтобы поместить текст**

Если вы хотите, чтобы текст в поле всегда помещался в это поле после внесения изменений в текст, вам нужно использовать опцию **Изменить размер фигуры, чтобы поместить текст**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на C++ показывает, как указать, что текст должен всегда помещаться в свое поле в презентации PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (высота увеличится), чтобы гарантировать, что весь текст помещается в него. Если текст становится короче, происходит обратное. 

## **Не подвергать автоматической подгонке**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры, независимо от изменений, внесенных в содержащий их текст, вам нужно использовать опцию **Не подвергать автоматической подгонке**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот код на C++ показывает, как указать, что текстовое поле должно всегда сохранять свои размеры в презентации PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Когда текст становится слишком длинным для своего поля, он выходит за его пределы. 

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своего поля, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и расстояние текста должны быть уменьшены, чтобы он поместился в свое поле. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код на C++ показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Информация" color="info" %}}

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только в том случае, если текст становится слишком длинным для своего поля.

{{% /alert %}}

## **Переносить текст**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст превышает пределы фигуры (только по ширине), вам нужно использовать параметр **Переносить текст в фигуре**. Чтобы указать эту настройку, вам нужно установить свойство [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в `true`.

Этот код на C++ показывает, как использовать настройку переноса текста в презентации PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Примечание" color="warning" %}} 

Если вы установите свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее ширины фигуры, текст продолжается за пределами границ фигуры в одну строку.

{{% /alert %}}
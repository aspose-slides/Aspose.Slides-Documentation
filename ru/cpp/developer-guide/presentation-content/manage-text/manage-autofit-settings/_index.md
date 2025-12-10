---
title: Улучшите свои презентации с помощью AutoFit в C++
linktitle: Настройки Autofit
type: docs
weight: 30
url: /ru/cpp/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не использовать автоподгонку
- подгонка текста
- уменьшить текст
- перенос текста
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для C++, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и улучшить читаемость содержимого."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fix text** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы гарантировать, что текст всегда помещается в нём. 

![Текстовое поле в PowerPoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — повышает его высоту — чтобы разместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — снижает его высоту — чтобы убрать лишнее пространство. 

В PowerPoint это четыре важных параметра или опции, управляющие поведением автоподгонки для текстового поля: 

* **Не использовать автоподгонку**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры под текст**
* **Перенос текста в фигуре.**

![Параметры автоподгонки в PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ предоставляет аналогичные параметры — некоторые методы класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) — которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях. 

## **Изменить размер фигуры под текст**

Если вы хотите, чтобы текст в блоке всегда помещался в этот блок после внесения изменений, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в значение `Shape`. 

![Параметр всегда подгонять в PowerPoint](alwaysfit-setting-powerpoint.png)

Этот код C++ показывает, как указать, что текст всегда должен помещаться в свой блок в презентации PowerPoint:
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


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст помещался в нём. Если текст становится короче, произойдет обратное. 

## **Не использовать автоподгонку**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, необходимо использовать параметр **Do not Autofit**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в значение `None`. 

![Параметр без автоподгонки в PowerPoint](donotautofit-setting-powerpoint.png)

Этот код C++ показывает, как указать, что текстовое поле должно всегда сохранять свои размеры в презентации PowerPoint:
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


Когда текст становится слишком длинным для своего блока, он выходит за его пределы. 

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своего блока, с помощью параметра **Shrink text on overflow** можно указать, что размер и межбуквенный интервал текста должны быть уменьшены, чтобы он поместился. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в значение `Normal`. 

![Параметр уменьшения текста при переполнении в PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код C++ показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
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


{{% alert title="Info" color="info" %}}
Когда используется параметр **Shrink text on overflow**, настройка применяется только тогда, когда текст становится слишком длинным для своего блока. 
{{% /alert %}}

## **Перенос текста**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда он выходит за её границу (только ширина), необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, установите свойство [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (из класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) в значение `true`. 

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


{{% alert title="Note" color="warning" %}} 
Если установить свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее её ширины, текст будет выходить за границы фигуры в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового фрейма на AutoFit?**

Да. Padding (внутренние отступы) уменьшает доступную площадь для текста, поэтому AutoFit срабатывает раньше — уменьшает шрифт или изменяет размер фигуры быстрее. Проверьте и отрегулируйте отступы перед настройкой AutoFit. 

**Как AutoFit взаимодействует с ручными и мягкими переносами строк?**

Принудительные переносы остаются на месте, а AutoFit адаптирует размер шрифта и интервал вокруг них. Удаление ненужных переносов часто снижает степень, с которой AutoFit вынужден уменьшать текст. 

**Влияет ли изменение шрифта темы или замена шрифтов на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов изменяет ширину/высоту текста, что может изменить окончательный размер шрифта и перенос строк. После любой смены шрифта или подстановки повторно проверьте слайды.
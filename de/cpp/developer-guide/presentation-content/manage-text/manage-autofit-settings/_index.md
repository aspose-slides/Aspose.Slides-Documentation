---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in C++
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/cpp/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Kein Autofit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie AutoFit-Einstellungen in Aspose.Slides für C++ verwalten, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfeldes die **Resize shape to fix text**‑Einstellung für das Textfeld – es ändert automatisch die Größe des Textfeldes, damit sein Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – erhöht die Höhe – um mehr Text aufnehmen zu können. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld automatisch – verringert die Höhe – um überflüssigen Raum zu entfernen. 

In PowerPoint sind dies die vier wichtigen Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfeldes steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für C++ bietet ähnliche Optionen — einige Methoden der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) — mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können. 

## **Größe einer Form an Text anpassen**

Wenn Sie möchten, dass der Text in einer Box immer in diese Box passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die **Resize shape to fix text**‑Option verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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


Wenn der Text länger oder größer wird, wird das Textfeld automatisch in der Höhe vergrößert, sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Do Not Autofit**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehält, müssen Sie die **Do not Autofit**‑Option verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) auf `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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


Wenn der Text zu lang für seine Box wird, läuft er heraus. 

## **Shrink Text on Overflow**

Wenn ein Text zu lang für seine Box ist, können Sie mit der **Shrink text on overflow**‑Option festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in die Box passt. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
Wenn die **Shrink text on overflow**‑Option verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für seine Box wird. 
{{% /alert %}}

## **Wrap Text**

Wenn Sie möchten, dass der Text in einer Form umgebrochen wird, sobald er die Breite der Form überschreitet, müssen Sie den Parameter **Wrap text in shape** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) auf `true`. 

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
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `False` setzen, wird bei zu langem Text die Zeile über die Formgrenzen hinaus in einer einzigen Zeile erweitert. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textfelds das AutoFit?**

Ja. Innenabstände verkleinern die nutzbare Textfläche, sodass AutoFit früher greift — die Schrift wird eher verkleinert oder die Form früher angepasst. Prüfen und korrigieren Sie die Ränder, bevor Sie AutoFit feinjustieren.

**Wie verhält sich AutoFit bei manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand um sie herum an. Das Entfernen unnötiger Umbrüche reduziert oft das Bedürfnis von AutoFit, den Text stark zu verkleinern.

**Wirkt sich das Ändern der Design‑Schrift oder das Auslösen einer Schrift‑Substitution auf die AutoFit‑Ergebnisse aus?**

Ja. Der Austausch gegen eine Schrift mit anderen Glyph‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und den Zeilenumbruch beeinflussen kann. Nach jeder Schriftänderung bzw. -Substitution die Folien erneut prüfen.
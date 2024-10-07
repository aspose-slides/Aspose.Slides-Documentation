---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /cpp/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Stellen Sie die Autofit-Einstellungen für Textfelder in PowerPoint in C++ ein"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Form resize to fit text** für das Textfeld – es passt die Größe des Textfelds automatisch an, um sicherzustellen, dass der Text immer hineinpasst.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint automatisch das Textfeld – erhöht die Höhe – um mehr Text aufnehmen zu können.
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint automatisch das Textfeld – verringert die Höhe – um überflüssigen Raum zu beseitigen.

In PowerPoint gibt es 4 wichtige Parameter oder Optionen, die das Autofit-Verhalten für ein Textfeld steuern:

* **Nicht Autofit**
* **Text bei Überlauf verkleinern**
* **Form anpassen, um Text anzupassen**
* **Text in der Form umschließen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für C++ bietet ähnliche Optionen – einige Methoden in der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) Klasse – die es Ihnen ermöglichen, das Autofit-Verhalten für Textfelder in Präsentationen zu steuern.

## **Form Anpassen, um Text anzupassen**

Wenn Sie möchten, dass der Text in einem Feld immer in dieses Feld passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Form resize to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) Klasse) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser C++-Code zeigt Ihnen, wie Sie angeben, dass ein Text immer in sein Feld in einer PowerPoint-Präsentation passen muss:

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

Wenn der Text länger oder größer wird, wird das Textfeld automatisch (Höhenvergrößerung) angepasst, um sicherzustellen, dass der gesamte Text hineinpasst. Wenn der Text kürzer wird, passiert das Gegenteil.

## **Nicht Autofit**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unabhängig von den Änderungen, die am enthaltenen Text vorgenommen werden, beibehält, müssen Sie die Option **Nicht Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) Klasse) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser C++-Code zeigt Ihnen, wie Sie angeben, dass ein Textfeld immer seine Abmessungen in einer PowerPoint-Präsentation beibehalten muss:

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

Wenn der Text zu lang für sein Feld wird, überläuft er.

## **Text bei Überlauf Verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie über die Option **Text bei Überlauf verkleinern** festlegen, dass die Größe und der Abstand des Textes reduziert werden müssen, um in das Feld zu passen. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) Klasse) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser C++-Code zeigt Ihnen, wie Sie angeben, dass ein Text in einer PowerPoint-Präsentation bei Überlauf verkleinert werden muss:

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

Wenn die Option **Text bei Überlauf verkleinern** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird.

{{% /alert %}}

## **Text Umrahmen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umschlossen wird, wenn der Text die Grenze der Form (nur Breite) überschreitet, müssen Sie den Parameter **Text in Form umschließen** verwenden. Um diese Einstellung festzulegen, müssen Sie die [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) Klasse) auf `true` setzen.

Dieser C++-Code zeigt Ihnen, wie Sie die Wrap Text-Einstellung in einer PowerPoint-Präsentation verwenden:

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

{{% alert title="Hinweis" color="warning" %}}

Wenn Sie die `WrapText`-Eigenschaft auf `False` für eine Form setzen, wird der Text, der innerhalb der Form länger wird als die Breite der Form, über die Grenzen der Form hinaus in einer einzigen Linie verlängert.

{{% /alert %}}
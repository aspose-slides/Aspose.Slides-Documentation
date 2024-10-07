---
title: Präsentationshintergrund
type: docs
weight: 20
url: /cpp/presentation-background/
keywords: "PowerPoint Hintergrund, Hintergrund einstellen"
description: "Hintergrund in PowerPoint-Präsentation in CPP einstellen"
---

Einfarbige Farben, Farbverläufe und Bilder werden häufig als Hintergrundbilder für Folien verwendet. Sie können den Hintergrund entweder für eine **normale Folie** (einzelne Folie) oder **Masterfolie** (mehrere Folien gleichzeitig) festlegen.

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Einfarbigen Hintergrund für normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen (auch wenn diese Präsentation eine Masterfolie enthält). Die Hintergrundänderung betrifft nur die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) Enum für den Folienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) bereitgestellt wird, um eine einfarbige Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie eine einfarbige Farbe (blau) als Hintergrund für eine normale Folie festlegen:

```c++
// Der Pfad zum Dokumentenverzeichnis.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Erstellt eine Instanz der Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//  Setzt die Hintergrundfarbe für die erste ISlide auf Blau
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	//Schreibt die Präsentation auf die Festplatte
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Einfarbigen Hintergrund für Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die Formatierungseinstellungen für alle Folien enthält und steuert. Daher wird, wenn Sie eine einfarbige Farbe als Hintergrund für die Masterfolie auswählen, dieser neue Hintergrund für alle Folien verwendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) Enum für die Masterfolie (`Masters`) auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) Enum für den Hintergrund der Masterfolie auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) bereitgestellt wird, um eine einfarbige Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie eine einfarbige Farbe (forstgrün) als Hintergrund für eine Masterfolie in einer Präsentation festlegen:

```c++
	// Der Pfad zum Dokumentenverzeichnis.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Erstellt eine Instanz der Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Setzt die Hintergrundfarbe für die Master ISlide auf Forstgrün
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	//Schreibt die Präsentation auf die Festplatte
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Farbverlauf als Hintergrund für Folie festlegen**

Ein Farbverlauf ist ein grafischer Effekt, der auf einer allmählichen Farbänderung basiert. Farbverläufe, die als Hintergründe für Folien verwendet werden, lassen Präsentationen künstlerisch und professionell erscheinen. Aspose.Slides ermöglicht es Ihnen, eine Farbverlauf als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) Enum für den Hintergrund der Masterfolie auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) bereitgestellt wird, um Ihre bevorzugte Gradieneinstellung anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie einen Farbverlauf als Hintergrund für eine Folie festlegen:

```c++
// Erstellt eine Instanz der Präsentationsklasse
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Wendet den Farbverlaufseffekt auf den Hintergrund an
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Schreibt die Präsentation auf die Festplatte
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Bild als Hintergrund für Folie festlegen**

Neben einfarbigen Farben und Farbverläufen ermöglicht es Aspose.Slides auch, Bilder als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) Enum für den Hintergrund der Masterfolie auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild in die Bildsammlung der Präsentation ein.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) bereitgestellt wird, um das Bild als Hintergrund festzulegen.
7. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```c++
// Der Pfad zum Dokumentenverzeichnis.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Erstellt eine Instanz der Präsentationsklasse
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Setzt Bedingungen für das Hintergrundbild
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Lädt das Bild
auto image = Images::FromFile(imagePath);

// Fügt das Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Schreibt die Präsentation auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Transparenz des Hintergrundbildes ändern**

Sie möchten möglicherweise die Transparenz eines Folienhintergrundbilds anpassen, um die Inhalte der Folie hervorzuheben. Dieser C++-Code zeigt Ihnen, wie Sie die Transparenz für ein Folienhintergrundbild ändern:

```c++
int32_t transparencyValue = 30;
// zum Beispiel
// Holt eine Sammlung von Bildtransformationsoperationen
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// Findet einen Transparenzeffekt mit festem Prozentsatz.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// Setzt den neuen Transparenzwert.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides bietet das [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) Interface, um Ihnen zu ermöglichen, die effektiven Werte von Folienhintergründen abzurufen. Dieses Interface enthält Informationen über die effektive [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) und die effektive [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8).

Verwenden Sie die [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) Eigenschaft der [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/) Klasse, um den effektiven Wert für einen Folienhintergrund abzurufen.

Dieser C++-Code zeigt Ihnen, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```c++
// Erstellt eine Instanz der Präsentationsklasse
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"Füllfarbe: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"Fülltyp: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```
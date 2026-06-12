---
title: Verbeter uw presentaties met AutoFit in C++
linktitle: Autofit‑instellingen
type: docs
weight: 30
url: /nl/cpp/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofit
- tekst aanpassen
- tekst verkleinen
- tekst afbreken
- vorm aanpassen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u AutoFit‑instellingen in Aspose.Slides voor C++ kunt beheren om de weergave van tekst in uw PowerPoint‑ en OpenDocument‑presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de **Resize shape to fix text** instelling voor het tekstvak – het vergroot of verkleint het tekstvak automatisch zodat de tekst er altijd in past. 

![tekstvak-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint het tekstvak automatisch – de hoogte wordt vergroot – zodat het meer tekst kan bevatten. 
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint het tekstvak automatisch – de hoogte wordt verkleind – om overtollige ruimte te verwijderen. 

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak bepalen: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-opties-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ biedt vergelijkbare opties – enkele methoden onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format)‑klasse – die je in staat stellen het autofit‑gedrag voor tekstvakken in presentaties te regelen. 

## **Vorm aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat de tekst is aangepast, moet je de **Resize shape to fix text** optie gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format)‑klasse) in op `Shape`.

![altijd-passende-instelling-powerpoint](alwaysfit-setting-powerpoint.png)

Deze C++‑code laat zien hoe je aangeeft dat een tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

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

Wordt de tekst langer of groter, dan wordt het tekstvak automatisch vergroot (de hoogte wordt verhoogd) zodat alle tekst erin past. Wordt de tekst korter, gebeurt het tegenovergestelde. 

## **Niet automatisch aanpassen**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst, moet je de **Do not Autofit** optie gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format)‑klasse) in op `None`. 

![niet-autofit-instelling-powerpoint](donotautofit-setting-powerpoint.png)

Deze C++‑code laat zien hoe je aangeeft dat een tekstvak zijn afmetingen altijd moet behouden in een PowerPoint‑presentatie:

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

Wordt de tekst te lang voor het vak, dan stroomt deze buiten het vak. 

## **Tekst verkleinen bij overflow**

Als een tekst te lang wordt voor zijn vak, kun je via de **Shrink text on overflow** optie aangeven dat de tekstgrootte en -spatiëring moeten worden verkleind zodat deze in het vak past. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format)‑klasse) in op `Normal`.

![verklein-tekst-bij-overflow-instelling-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze C++‑code laat zien hoe je aangeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

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
Wanneer de **Shrink text on overflow** optie wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor het vak. 
{{% /alert %}}

## **Tekst omwikkelen**

Wil je dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst de rand van de vorm (alleen de breedte) overschrijdt, dan moet je de **Wrap text in shape** parameter gebruiken. Om deze instelling te specificeren, moet je de [WrapText](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame_format)‑klasse) op `true` zetten. 

Deze C++‑code laat zien hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

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

{{% alert title="Opmerking" color="warning" %}} 
Als je de `WrapText`‑eigenschap op `False` zet voor een vorm, wordt de tekst, zodra deze langer wordt dan de breedte van de vorm, over de vormranden heen voortgezet op één enkele regel. 
{{% /alert %}}

## **Veelgestelde vragen**

**Heeft de interne marge van het tekstkader invloed op AutoFit?**  
Ja. Padding (interne marges) verkleint het bruikbare tekstgebied, waardoor AutoFit eerder ingrijpt – het lettertype wordt eerder verkleind of de vorm eerder vergroot. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit in combinatie met handmatige en zachte regeleinden?**  
Geforceerde regeleinden blijven behouden, en AutoFit past lettergrootte en spatiëring hieromheen aan. Het verwijderen van onnodige regeleinden vermindert vaak de noodzaak voor agressief verkleinen door AutoFit.

**Beïnvloeden het wijzigen van de thema‑lettertype of het inschakelen van lettertype‑substituties de AutoFit‑resultaten?**  
Ja. Een substitutie naar een lettertype met andere glyph‑metingen verandert de tekstbreedte/-hoogte, wat de uiteindelijke lettergrootte en regelafbreking kan wijzigen. Controleer de dia’s na elke lettertype‑wijziging of substitutie.
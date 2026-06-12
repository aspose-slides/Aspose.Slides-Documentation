---
title: Beheer presentatie‑plaatsaanduiders in C++
linktitle: Beheer plaatsaanduiders
type: docs
weight: 10
url: /nl/cpp/manage-placeholder/
keywords:
- plaatsaanduiding
- tekstplaatsaanduiding
- afbeeldingsplaatsaanduiding
- grafiekplaatsaanduiding
- prompttekst
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer moeiteloos plaatsaanduiders in Aspose.Slides voor C++: vervang tekst, pas prompts aan en stel afbeeldings‑transparantie in PowerPoint en OpenDocument in."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentatie‑plaatsaanduiders programmatisch te beheren. Dit artikel legt uit hoe u plaatsaanduiders op dia’s kunt vinden en hun tekst kunt wijzigen, aangepaste prompt‑tekst kunt instellen voor plaatsaanduidingslay‑outs, en de transparantie van een afbeelding die als achtergrond van een plaatsaanduider wordt gebruikt kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basis‑plaatsaanduiders en lokale vormen verduidelijkt, uitlegt hoe plaatsaanduidingswijzigingen kunnen worden toegepast via lay‑outs of masters, en wijst op het beheer van kop‑ en voettekst‑plaatsaanduiders.

## **Tekst wijzigen in een plaatsaanduider**

Met [Aspose.Slides for C++](/slides/nl/cpp/) kunt u plaatsaanduiders op dia’s in presentaties vinden en aanpassen. Aspose.Slides maakt het mogelijk om de tekst in een plaatsaanduider te wijzigen.

**Prerequisite**: U heeft een presentatie nodig die een plaatsaanduider bevat. Zo’n presentatie kunt u maken met de standaard Microsoft PowerPoint‑applicatie.

Zo gebruikt u Aspose.Slides om de tekst in de plaatsaanduider in die presentatie te vervangen:

1. Instantieer de klasse [`Presentation`](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) en geef de presentatie als argument door.
2. Haal een dia‑referentie op via de index.
3. Itereer door de vormen om de plaatsaanduider te vinden.
4. Zet de plaatsaanduidingsvorm om naar een [`AutoShape`](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.auto_shape/) en wijzig de tekst met behulp van het [`TextFrame`](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame/) dat bij de [`AutoShape`](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.auto_shape/) hoort.
5. Sla de aangepaste presentatie op.

Deze C++‑code toont hoe u de tekst in een plaatsaanduider kunt wijzigen:

```c++
// Het pad naar de documentmap.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Benadert de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Benadert de eerste en tweede plaatsaanduider op de dia en zet deze om naar een AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Slaat de presentatie op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Prompt‑tekst instellen in een plaatsaanduider**

Standaard‑ en vooraf gebouwde lay‑outs bevatten prompt‑teksten voor plaatsaanduiders, zoals ***Click to add a title*** of ***Click to add a subtitle***. Met Aspose.Slides kunt u uw eigen gewenste prompt‑teksten in plaatsaanduidingslay‑outs invoegen.

Deze C++‑code laat zien hoe u de prompt‑tekst in een plaatsaanduider kunt instellen:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Wanneer er geen tekst in staat, toont PowerPoint "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Doet hetzelfde voor ondertitel.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Transparantie van plaatsaanduidingsafbeelding instellen**

Aspose.Slides maakt het mogelijk om de transparantie van de achtergrondafbeelding in een tekst‑plaatsaanduider in te stellen. Door de transparantie van de afbeelding in zo’n frame aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze C++‑code toont hoe u de transparantie voor een afbeelding‑achtergrond (binnen een vorm) kunt instellen:

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

## **FAQ**

**Wat is een basis‑plaatsaanduider en hoe verschilt deze van een lokale vorm op een dia?**

Een basis‑plaatsaanduider is de oorspronkelijke vorm op een lay‑out of master waarvan de vorm op de dia erft — type, positie en enkele opmaakkenmerken komen hiervan. Een lokale vorm staat op zichzelf; als er geen basis‑plaatsaanduider is, is er geen overerving.

**Hoe kan ik alle titels of bijschriften in een presentatie bijwerken zonder over elke dia te itereren?**

Bewerk de overeenkomstige plaatsaanduider op de lay‑out of de master. Dia’s die gebaseerd zijn op die lay‑outs/master erven de wijziging automatisch.

**Hoe beheer ik de standaard kop‑/voettekst‑plaatsaanduiders — datum en tijd, dia‑nummer en voettekst?**

Gebruik de HeaderFooter‑managers op het juiste niveau (normale dia’s, lay‑outs, master, notities/hand‑outs) om die plaatsaanduiders in of uit te schakelen en om hun inhoud in te stellen.
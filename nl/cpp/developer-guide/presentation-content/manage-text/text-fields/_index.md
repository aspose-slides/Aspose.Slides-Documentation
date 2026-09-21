---
title: Beheer tekstvelden in PowerPoint-presentaties in C++
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/cpp/text-fields/
keywords:
- tekstveld
- automatische tekst
- slide-nummer
- datum en tijd
- koptekst
- voettekst
- tekstdeel
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor C++. Behoud de opmaak en controleer de opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit segmenten. Een gewone [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) bevat letterlijke tekst; een veldsegment heeft ook een [IField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifield/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een slide‑nummer of datum. Twee segmenten kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [IPortion::get_Field](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_field/) om ze te onderscheiden: het geeft `nullptr` terug voor gewone tekst. [IPortion::AddField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/addfield/) zet een bestaand segment om in een veld. Houd een label en zijn dynamische waarde in gescheiden segmenten zodat het converteren van de waarde niet ook het label vervangt.

Deze gids behandelt velden binnen tekst, hun opmaak, en het opslaan ervan in PPTX en PPT. Voor tekstframes en -paragrafen, zie [Manage Text](/slides/nl/cpp/manage-text/).

## **Maak een slide‑nummerveld**

Het volgende voorbeeld maakt een tekstvak met een letterlijke `Slide `‑label gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, het gewicht en de kleur van het nummer in vóór het toevoegen van het veld, opent vervolgens de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

De nieuwe presentatie start met slide‑nummer 1, dus de verwachte tekst is `Slide 1`, en beide controles moeten `True` weergeven. Het nummer blijft een veld na het heropenen; het is geen letterlijke `1`. De cast en indexen in de verificatie verwijzen naar de vorm en segmenten die door dit voorbeeld zijn aangemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/) implementeert [IFieldType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifieldtype/) en biedt de volgende vooraf gedefinieerde waarden. Geef de juiste waarde door aan [AddField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/addfield/).

| Accessor | Doel |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_slidenumber/) | Het huidige slide‑nummer. |
| [get_DateTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime/) | Datum/tijd in het standaardformaat van de renderende applicatie. |
| [get_DateTime1](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime1/)-[get_DateTime9](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime9/) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [get_DateTime10](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime10/)-[get_DateTime13](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime13/) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [get_Header](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_header/) | Een header‑veld; zie hieronder de beperkingen voor placeholder en formaat. |
| [get_Footer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_footer/) | Een footer‑veld. |

Bijvoorbeeld, [get_DateTime3](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/get_datetime3/) levert een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige datum‑formatteer‑strings. De taal van het segment, ingesteld met [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/), en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Maak een veld aan vanuit een interne string**

De string‑overload van [AddField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/addfield/) accepteert een interne veld‑identifier. Gebruik deze wanneer je een identifier wilt behouden die door een andere applicatie is geleverd en geen vooraf gedefinieerde waarde heeft. Je kunt ook een [FieldType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fieldtype/fieldtype/) van de identifier construeren. [IFieldType::get_InternalString](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifieldtype/get_internalstring/) maakt die identifier zichtbaar voor inspectie.

Dit voorbeeld slaat een applicatie‑specifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. Er is geen invoerbestand vereist. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑ID’s voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Na deze PPTX‑rondreis is het verwachte type `custom-report-id` en de verwachte tekst `Report-042`. Het doorgeven van een string zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum‑/tijd‑velden**

Lees een bestaand veldtype via [IField::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifield/get_type/) en wijzig het via [IField::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifield/set_type/). Controleer dat het veld bestaat voordat je het type aanspreekt. Om automatische updates te stoppen, roep [IPortion::RemoveField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/removefield/) aan. Dit behoudt het segment en de huidige tekst terwijl de veldkoppeling wordt verwijderd. Als je een specifieke vaste waarde nodig hebt, ken die tekst dan toe na het verwijderen van het veld.

Voor de API‑instelling die verband houdt met de verwerking van datum‑/tijd‑velden, zie [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/set_currentdatetime/). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkdirectory. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum‑/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de bovenste‑niveau tekstvormen op gewone slides. Het verandert datum‑/tijd‑velden naar een lange datum‑opmaak en maakt ze cursief, terwijl de andere opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

Het voorbeeld herkent de ingebouwde interne identifier‑s `datetime` en `datetime1` tot `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen een doorloop van hun eigen tekstcontainers en vallen buiten de reikwijdte van dit voorbeeld.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Na het heropenen moet `UpdatedAt` type `datetime3` hebben en dynamisch blijven. `ApprovedDate` mag geen veld hebben en de tekst `05 April 2030` bevatten. Beide datumsegmenten zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven behouden. De gewone tekstlabels blijven ongewijzigd. De verificatie leest het eerste segment van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met het bestaande segment bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van dat segment. Gebruik [IPortion::get_PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_portionformat/) om alleen de benodigde eigenschappen aan te passen, zoals de voorbeelden doen voor kleur of cursief.

Vermijd het volledig opnieuw opbouwen van een tekstframe alleen om één veld bij te werken: dit kan de oorspronkelijke segmentgrenzen en hun individuele opmaak verliezen. Maak ook onderscheid tussen expliciet ingestelde opmaak en opmaak die is geërfd van de alinea, lay‑out of thema. Zie [Text Formatting](/slides/nl/cpp/text-formatting/) voor bredere opmaakopties.

## **Velden en kop‑/voettekst‑placeholder‑s**

Een veld maakt deel uit van een tekstsegment. Een placeholder is een vorm met een presentatierol, zoals een footer of slide‑nummer. Het toevoegen van een veld aan een gewone tekstvak maakt die vorm niet tot een placeholder.

De kop‑/voettekst‑beheerders regelen placeholder‑tekst en zichtbaarheid op slides, lay‑outs en masters, inclusief voortzetting naar afhankelijke slides. Een nummer‑veld in een aangepast tekstvak kan daarom nuttig zijn, zelfs wanneer je de slide‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerd tekstvak.

De vooraf gedefinieerde kop‑ en voettekst‑types creëren de overeenkomstige placeholders niet en leveren hun inhoud niet. Met name heeft een gewone PowerPoint‑slide geen header‑placeholder; kopteksten behoren bij notitie‑pagina’s en hand‑outs. Ga er niet van uit dat een header‑ of footer‑veld in een willekeurige vorm automatisch de via een placeholder‑manager ingestelde tekst krijgt. Zie voor die workflow [Presentation Headers and Footers](/slides/nl/cpp/presentation-header-and-footer/).

## **PPTX‑ en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en heropenen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag en beperkingen van het veld |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast de veldtekst. Gebruik de bovenstaande voorbeelden om vooraf gedefinieerde types en aangepaste identifiers te controleren na opslaan en heropenen. Een onbekend aangepast type krijgt geen automatische berekeningslogica. Een andere applicatie kan niet‑ondersteunde identifiers anders behandelen. |
| PPT | Gebruikt verouderde veldrepresentaties en heeft een beperktere compatibiliteit. Slide‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden hebben verouderde representaties. Niet‑ondersteunde aangepaste velden of header‑velden in een gewone slide‑tekstvak kunnen `*` als tekst produceren. Vertrouw niet op dat aangepaste velden of niet‑ondersteunde veld‑contexten hun zichtbare tekst behouden. |

Voor draagbare, vaste output, converteer niet‑ondersteunde velden naar gewone tekst en ken expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test de doelapplicatie ook wanneer haar eigen veldherberekening deel uitmaakt van je workflow.

## **FAQ**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [IPortion::get_Field](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_field/). Een niet‑null waarde identificeert een veld; de weergegeven tekst alleen kan het niet bepalen.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [RemoveField](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/removefield/) zet het bestaande segment om naar gewone tekst. Ken daarna een expliciete waarde toe als je een specifieke bevroren datum of fallback‑waarde nodig hebt.

**Kan een interne string een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of datum‑formaatpatroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veld‑identifiers, berekende tekst en opmaak zijn afzonderlijke zaken om te verifiëren. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.
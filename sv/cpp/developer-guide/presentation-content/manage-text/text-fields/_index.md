---
title: Hantera textfält i PowerPoint-presentationer i C++
linktitle: Textfält
type: docs
weight: 52
url: /sv/cpp/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- sidhuvud
- sidfot
- textavsnitt
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för C++. Bevara formatering och kontrollera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textstycke består av delar. En vanlig [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/) innehåller bokstavlig text; ett fältavsnitt har också en [IField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifield/) vars typ identifierar ett automatiskt uppdaterat värde, till exempel ett bildnummer eller datum. Två delar kan visa samma tecken medan bara en innehåller ett fält.

Använd [IPortion::get_Field](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_field/) för att särskilja dem: den returnerar `nullptr` för vanlig text. [IPortion::AddField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/addfield/) omvandlar ett befintligt avsnitt till ett fält. Håll en etikett och dess dynamiska värde i separata delar så att konvertering av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och att spara dem i PPTX och PPT. För textramar och stycken, se [Hantera text](/slides/sv/cpp/manage-text/).

## **Skapa ett bildnummerfält**

Följande exempel skapar en textruta som innehåller en bokstavlig `Slide `-etikett följd av ett automatiskt uppdaterat nummer. Det anger numrets storlek, viktningsgrad och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fältets typ, text och formatering. Ingen indatafil krävs.

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

Den nya presentationen startar med bildnummer 1, så den förväntade texten är `Slide 1`, och båda kontrollerna bör skriva ut `True`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Typomvandlingen och indexen i verifieringen hänvisar till formen och avsnitten som skapats av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/) implementerar [IFieldType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifieldtype/) och tillhandahåller följande fördefinierade värden. Skicka det lämpliga värdet till [AddField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/addfield/).

| Åtkomst | Syfte |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_slidenumber/) | Det aktuella bildnumret. |
| [get_DateTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime/) | Datum/tid i renderingsapplikationens standardformat. |
| [get_DateTime1](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime9/) | Fördefinierade datum- eller kombinerade datum/tidsformat. |
| [get_DateTime10](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime13/) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [get_Header](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_header/) | Ett sidhuvudsfält; se platshållaren och formatbegränsningarna nedan. |
| [get_Footer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_footer/) | Ett sidfotsfält. |

Till exempel ger [get_DateTime3](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/get_datetime3/) en dag, fullständigt månadsnamn och år på engelska. Dessa är fördefinierade fältformat, inte godtyckliga datumformatsträngar. Avsnittets språk, som sätts med [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_languageid/), och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Stringöverladdningen av [AddField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/addfield/) accepterar en intern fältidentifierare. Använd den när du behåller en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fieldtype/fieldtype/) från identifieraren. [IFieldType::get_InternalString](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifieldtype/get_internalstring/) visar den identifieraren för granskning.

Detta exempel lagrar ett program‑specifikt `custom-report-id`‑fält med reservtexten `Report-042`. Ingen indatafil krävs. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

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

Efter denna PPTX‑rundresa är den förväntade typen `custom-report-id` och den förväntade texten `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; det skulle inte konfigurera ett anpassat datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tidsfält**

Läs en befintlig fälttyp via [IField::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifield/get_type/) och ändra den via [IField::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifield/set_type/). Kontrollera att fältet finns innan du kommer åt dess typ. För att stoppa automatiska uppdateringar, anropa [IPortion::RemoveField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/removefield/). Detta behåller avsnittet och dess aktuella text medan fältassociationen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att fältet tagits bort.

För API‑inställningen som är kopplad till bearbetning av datum/tidsfält, se [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/set_currentdatetime/). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textformer, `UpdatedAt` och `ApprovedDate`, var och en med ett datum/tidsfält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå‑textformer på vanliga bilder. Det ändrar datum/tidsfält till ett långdatumformat och gör dem kursiva, samtidigt som deras övriga formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, anteckningar, layouter och master‑bilder kräver traversering av deras egna textbehållare och ligger utanför detta exempel.

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

Efter att ha öppnat igen bör `UpdatedAt` ha typen `datetime3` och förbli dynamisk. `ApprovedDate` bör inte ha något fält och innehålla `05 April 2030`. Båda datumavsnitten är kursiva, och deras ursprungliga teckenstorlek, fetstilinställning och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser det första avsnittet av de två kända formerna i det medföljande exemplet.

## **Bevara textformatering**

Arbeta med det befintliga avsnittet när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller avsnittets formatering. Använd [IPortion::get_PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_portionformat/) för att ändra endast de nödvändiga egenskaperna, som exemplen gör för färg eller kursiv.

Undvik att bygga om hela en textruta bara för att uppdatera ett fält: det kan leda till att de ursprungliga avsnittsgränserna och deras individuella formatering förloras. Skilj också på explicit inställd formatering från formatering som ärvts från stycket, layouten eller temat. Se [Textformatering](/slides/sv/cpp/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfötter**

Ett fält är en del av ett textavsnitt. En platshållare är en form med en presentationsroll, såsom en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta gör inte formen till en platshållare.

Sidhuvuds-/sidfotshanterarna styr platshållartext och synlighet på bilder, layouter och master‑bilder, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt tar förändring av platshållarens synlighet inte bort ett fält från en orelaterad textruta.

De fördefinierade sidhuvuds- och sidfotstyperna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen sidhuvuds‑platshållare; sidhuvuden hör till notesidor och handouts. Anta inte att ett sidhuvuds‑ eller sidfotfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållar‑hanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/cpp/presentation-header-and-footer/).

## **PPTX- och PPT-begränsningar**

Kontrollera både fälttypen och dess resulterande text efter att ha sparat och öppnat igen. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttext. Använd exemplen ovan för att kontrollera fördefinierade typer och anpassade identifierare efter att ha sparat och öppnat igen. En okänd anpassad typ får inte automatiskt beräkningslogik. En annan applikation kan hantera ostödda identifierare på ett annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Bildnummer‑ och fördefinierade datum/tids‑fält har äldre representationer. Ostödda anpassade fält eller sidhuvuds‑fält i en vanlig bildtextruta kan producera `*` som deras text. Lita inte på att anpassade fält eller ostödda fältkontexter behåller sin synliga text. |

För portabel, fast utdata, konvertera ostödda fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egen fältåterberäkning är en del av ditt arbetsflöde.

## **Vanliga frågor**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [IPortion::get_Field](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_field/). ett icke‑null‑värde identifierar ett fält; den visade texten ensam kan inte berätta det.

**Tar bort ett fält bort dess text eller formatering?**

Nej. [RemoveField](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/removefield/) konverterar det befintliga avsnittet till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett särskilt fruset datum eller reservvärde.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare tillhandahåller ingen evaluator eller ett datumformatmönster. Använd en stödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan förändra det synliga resultatet även när fältidentifieraren fortfarande finns.
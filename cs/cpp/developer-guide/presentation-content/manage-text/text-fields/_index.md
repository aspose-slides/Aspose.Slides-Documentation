---
title: Spravování textových polí v prezentacích PowerPoint v C++
linktitle: Textová pole
type: docs
weight: 52
url: /cs/cpp/text-fields/
keywords:
- textové pole
- automatický text
- číslo snímku
- datum a čas
- záhlaví
- zápatí
- textová část
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Vytvářejte, prohlížejte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Zachovejte formátování a zkontrolujte uložené soubory PPTX a PPT."
---
## **Přehled**

Odstavec textu se skládá z částí. Běžná [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) obsahuje doslovný text; část pole má také [IField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifield/), jehož typ identifikuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, přičemž jen jedna obsahuje pole.

K rozlišení použijte [IPortion::get_Field](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_field/): vrací `nullptr` pro běžný text. [IPortion::AddField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/addfield/) převede existující část na pole. Uchovávejte popisek a jeho dynamickou hodnotu v oddělených částech, aby převod hodnoty nevedl k nahrazení popisku.

Tento návod pokrývá pole uvnitř textu, jejich formátování a ukládání do PPTX a PPT. Pro textová pole a odstavce viz [Manage Text](/slides/cs/cpp/manage-text/).

## **Vytvoření pole čísla snímku**

Následující příklad vytvoří textové pole obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Před přidáním pole nastaví velikost, tloušťku a barvu čísla, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Vstupní soubor není vyžadován.

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

Nová prezentace začíná číslem snímku 1, takže očekávaný text je `Slide 1` a oba testy by měly vytisknout `True`. Číslo zůstane polem po znovuotevření; nejedná se o doslovnou `1`. Přetypování a indexy v ověření odkazují na tvar a části vytvořené tímto příkladem.

## **Výběr typu pole**

[FieldType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifieldtype/) a poskytuje následující předdefinované hodnoty. Předávejte vhodnou hodnotu metodě [AddField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/addfield/).

| Přístup | Účel |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_slidenumber/) | Aktuální číslo snímku. |
| [get_DateTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime/) | Datum/čas ve výchozím formátu vykreslovací aplikace. |
| [get_DateTime1](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime9/) | Předdefinované formáty data nebo kombinované formáty data/času. |
| [get_DateTime10](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime13/) | Předdefinované formáty času, s možností sekund a 12‑hodinové hodiny. |
| [get_Header](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_header/) | Pole záhlaví; viz omezení zástupců a formátů níže. |
| [get_Footer](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_footer/) | Pole zápatí. |

Například [get_DateTime3](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/get_datetime3/) poskytuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty pole, ne o libovolné řetězce formátu data. Jazyk části, nastavený pomocí [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_languageid/), a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Vytvoření pole z interního řetězce**

Přetížení metody [AddField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/addfield/) pro řetězec přijímá interní identifikátor pole. Použijte jej při zachování identifikátoru dodaného jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fieldtype/fieldtype/) z tohoto identifikátoru. [IFieldType::get_InternalString](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifieldtype/get_internalstring/) tento identifikátor zpřístupňuje pro kontrolu.

Tento příklad ukládá aplikací specifické pole `custom-report-id` s náhradním textem `Report-042`. Vstupní soubor není vyžadován. Identifikátor nezaregistruje výpočet: Aspose.Slides nenahrává ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

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

Po tomto průchodu PPTX se očekávaný typ bude `custom-report-id` a očekávaný text bude `Report-042`. Předání řetězce jako `yyyy-MM-dd` by vytvořilo typ pole; nenastaví vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Prohlížení, úprava a odebrání polí datum/čas**

Načtěte existující typ pole pomocí [IField::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifield/get_type/) a změňte jej pomocí [IField::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifield/set_type/). Ověřte, že pole existuje, před přístupem k jeho typu. Pro zastavení automatických aktualizací zavolejte [IPortion::RemoveField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/removefield/). Tím se zachová část a její aktuální text, zatímco se odstraní souvislost s polem. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odebrání pole.

Pro nastavení API související se zpracováním polí datum/čas viz [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/set_currentdatetime/). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary, `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, plus běžné textové popisky. Následující příklad prochází textové tvary nejvyšší úrovně na běžných snímcích. Mění pole datum/čas na dlouhý formát data a nastavuje je kurzívou, přičemž zachovává jejich další formátování. Pouze pole v `ApprovedDate` se stanou pevným textem.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až po `datetime13`. Skupiny, tabulky, poznámky, rozvržení a hlavní šablony vyžadují procházení jejich vlastních textových kontejnerů a jsou mimo rozsah tohoto příkladu.

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

Po opětovném otevření by `UpdatedAt` měl mít typ `datetime3` a zůstat dynamický. `ApprovedDate` by neměl mít pole a měl by obsahovat `05 April 2030`. Obě datumové části jsou kurzívou a jejich původní velikost písma, nastavení tučného stylu a barva zůstávají nedotčeny. Běžné textové popisky zůstávají nezměněny. Ověření čte první část dvou známých tvarů ve vzorku.

## **Zachování formátování textu**

Pracujte s existující částí při přidávání pole, změně jeho typu nebo odebrání. Tyto operace zachovají formátování této části. Použijte [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_portionformat/) k úpravě jen požadovaných vlastností, jak to ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámce jen kvůli aktualizaci jednoho pole: může to vést ke ztrátě původních hranic částí a jejich individuálního formátování. Také rozlišujte explicitně nastavené formátování od formátování zděděného z odstavce, rozvržení nebo motivu. Viz [Text Formatting](/slides/cs/cpp/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupci záhlaví/zápatí**

Pole je součástí textové části. Zástupce je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do běžného textového pole nepromění tento tvar na zástupce.

Správci záhlaví/zápatí řídí text zástupců a jejich viditelnost na snímcích, rozvrženích a hlavních šablonách, včetně šíření na závislé snímky. Číselné pole v uživatelském textovém poli může být užitečné i když nepoužíváte zástupce čísla snímku. Naopak změna viditelnosti zástupce neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupce ani neposkytují jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupce záhlaví; záhlaví patří stránkám poznámek a podkladům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený pomocí správce zástupců. Pro tento postup viz [Presentation Headers and Footers](/slides/cs/cpp/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Zkontrolujte jak typ pole, tak jeho výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace dokáže vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory polí spolu s textem pole. Použijte výše uvedené příklady k ověření předdefinovaných typů a vlastních identifikátorů po uložení a opětovném otevření. Neznámý vlastní typ nezíská automatickou logiku výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá zastaralé reprezentace polí a má omezenější kompatibilitu. Pole čísla snímku a předdefinovaná pole datum/čas mají zastaralé reprezentace. Nepodporovaná vlastní pole nebo pole záhlaví v běžném textovém poli snímku mohou produkovat `*` jako svůj text. Nespoléhejte se na to, že vlastní pole nebo nepodporované kontexty polí zachovají jejich viditelný text. |

Pro přenosný, pevný výstup převeďte nepodporovaná pole na běžný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím se zachová zvolený text, ale úmyslně se zastaví automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočet polí součástí vašeho postupu.

## **Často kladené otázky**

**Jak poznám, zda je zobrazené číslo nebo datum pole?**  
Prohlédněte si [IPortion::get_Field](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_field/). Nenulová hodnota identifikuje pole; samotný zobrazený text to nedokáže určit.

**Odstraní odebrání pole i jeho text nebo formátování?**  
Není. [RemoveField](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/removefield/) převádí existující část na běžný text. Pokud potřebujete konkrétní zamrznuté datum nebo náhradní hodnotu, přiřaďte po odstranění pole explicitní hodnotu.

**Může interní řetězec definovat nový formát data nebo vzorec?**  
Není. Identifikátor určuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani formátovací vzor data. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako běžný text.

**Proč znovu kontrolovat prezentaci po jejím uložení?**  
Identifikátory polí, vypočtený text a formátování jsou samostatné věci, které je třeba ověřit. Konverze formátu může změnit viditelný výsledek, i když identifikátor pole stále existuje.
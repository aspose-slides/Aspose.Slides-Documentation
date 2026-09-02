---
title: Načíst a aktualizovat informace o prezentaci v C++
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/cpp/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- zkontrolovat PPTX
- zkontrolovat PPT
- zkontrolovat ODP
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí C++ pro rychlejší poznatky a inteligentnější audit obsahu."
---
## **Přehled**

Aspose.Slides může identifikovat formát prezentace a přečíst metadata dokumentu bez vytvoření kompletního objektového modelu prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo prověřit vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/), stejně jako cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/).

## **Zkontrolovat formát prezentace**

Použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k inspekci souboru bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Metoda [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_loadformat/) hlásí detekovaný formát, například PPTX, PPT nebo ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Vytvořit lehký inventář prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) pro načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) ani nevyžaduje procházet kompletní objektový model prezentace.

Rozšířené vlastnosti poskytované rozhraním [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/) zahrnují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_slides/) | Celkový počet snímků. |
| [get_HiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Počet skrytých snímků. |
| [get_Notes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_notes/) | Počet snímků, které obsahují poznámky. |
| [get_Paragraphs](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [get_Words](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_words/) | Celkový počet slov. |
| [get_MultimediaClips](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Celkový počet audio a video klipů. |

Následující příklad čte tyto hodnoty bez vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a vypisuje kompaktní inventář. Kombinuje také [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_headingpairs/) s [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/) poskytuje název skupiny prostřednictvím [IHeadingPair::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/get_name/) a počet položek v této skupině pomocí [IHeadingPair::get_Count](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) vrací ploché, uspořádané pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátů**

Vlastnosti inventáře vrácené metodou [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace za účelem přepočítání těchto hodnot pro toto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která naposledy soubor uložila, neaktualizovala jeho dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může ukládat odpovídající souhrnné dokumentové vlastnosti. Pokud je vlastnost absentní nebo nebyla aktualizována výrobcem dokumentu, Aspose.Slides vrátí uloženou nebo výchozí hodnotu místo jejího výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty se nepřekrývají se všemi rozšířenými vlastnostmi specifickými pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupné a inventární vlastnosti mohou vracet výchozí hodnoty. Nepovažujte nulovou hodnotu ani prázdné pole za definitivní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) mohou být také změněny bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Aplikujte změny pomocí [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) a poté zapište svázanou prezentaci pomocí [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Následující obrázek ukazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad mění název a čas posledního uložení a zapisuje výsledek do nového souboru:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Následující obrázek ukazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany si přečtěte následující články:

- [Zabezpečit prezentace heslem](/slides/cs/cpp/password-protected-presentation/)
- [Zabezpečit prezentace proti zápisu](/slides/cs/cpp/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation::get_FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/). Zavolejte [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getembeddedfonts/) pro získání vložených písem a [FontsManager::GetFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getfonts/) pro získání písem používaných v prezentaci. Porovnejte oba výsledky, abyste našli písma, která jsou potřebná pro vykreslování, ale nejsou vložena.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) přes [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). To je vhodné pro lehký inventář. Pokud byla prezentace v paměti změněna, uložená metadata mohou chybět nebo být zastaralá, nebo potřebujete ověřit živé hodnoty – iterujte přes [Presentation::get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slides/) a prozkoumejte metodu [Slide::get_Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/get_hidden/) každého snímku.

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation::get_SlideSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slidesize/). Prozkoumejte [ISlideSize::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_size/) a [ISlideSize::get_Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_orientation/) a porovnejte aktuální nastavení s očekávanými předvolbami a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/) a prozkoumejte [ChartData::get_DataSourceType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Pro externí sešit přečtěte [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdrojů.

**Jak mohu vyhodnotit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Projděte [Presentation::get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slides/) a kolekci [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_shapes/) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály, a změřte reprezentativní vykreslení nebo export před tím, než označíte snímek za potvrzený výkonový úzký průsek.
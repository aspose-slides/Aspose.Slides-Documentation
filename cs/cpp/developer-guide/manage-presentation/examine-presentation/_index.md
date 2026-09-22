---
title: Načtení a aktualizace informací o prezentaci v C++
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
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v PowerPoint a OpenDocument prezentacích pomocí C++ pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Aspose.Slides dokáže identifikovat formát prezentace a přečíst metadata dokumentu, aniž by vytvářela kompletní objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventář nebo prověřit vlastnosti před rozhodnutím, zda prezentaci načíst a zpracovat.

Tento článek ukazuje lehkou kontrolu pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/), a také cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/).

## **Kontrola formátu prezentace**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/cpp/detect-presentation-source-format/) pro detekci po načtení a omezení starých toků PPT, PPS a POT.

Použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k prozkoumání souboru bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Metoda [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_loadformat/) vrací detekovaný formát, např. PPTX, PPT nebo ODP.

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

## **Vytvoření lehkého inventáře prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V takovém scénáři použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) k přečtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) ani nevyžaduje procházení kompletním objektovým modelem prezentace.

Rozšířené vlastnosti poskytované [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/) nabízejí následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_slides/) | Celkový počet snímků. |
| [get_HiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Počet skrytých snímků. |
| [get_Notes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_notes/) | Počet snímků obsahujících poznámky. |
| [get_Paragraphs](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [get_Words](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_words/) | Celkový počet slov. |
| [get_MultimediaClips](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Celkový počet audio a video klipů. |

Následující příklad čte tyto hodnoty bez vytváření objektu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a vypisuje kompaktní inventář. Také kombinuje [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_headingpairs/) s [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) pro zobrazení skupin obsahu, jako jsou fonty, motivy a názvy snímků.

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

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/) poskytuje název skupiny prostřednictvím [IHeadingPair::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/get_name/) a počet položek ve skupině prostřednictvím [IHeadingPair::get_Count](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) vrací ploché, uspořádané pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá ani neprochází objektový model prezentace, aby pro tento volání přepočítala tyto hodnoty. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány tvůrcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající souhrnné vlastnosti dokumentu. Pokud je vlastnost chybí nebo nebyla aktualizována tvůrcem dokumentu, Aspose.Slides vrací její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nezobrazujte nulovou hodnotu ani prázdné pole jako definitivní důkaz, že odpovídající obsah chybí.

Použijte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) lze také změnit bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Změny aplikujte pomocí [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) a poté zapište svázanou prezentaci pomocí [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Následující obrázek zobrazuje původní vlastnosti dokumentu PowerPoint prezentace.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

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

Následující obrázek zobrazuje změněné vlastnosti dokumentu PowerPoint prezentace.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související kontroly zabezpečení a nastavení ochrany viz následující články:

- [Zabezpečení prezentací heslem](/slides/cs/cpp/password-protected-presentation/)
- [Zabezpečení prezentací proti zápisu](/slides/cs/cpp/write-protected-presentation/)

## **FAQ**

**Jak mohu zjistit, zda jsou fonty vloženy a které to jsou?**

Načtěte prezentaci a použijte [Presentation::get_FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/). Zavolejte [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getembeddedfonts/) k získání vložených fontů a [FontsManager::GetFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getfonts/) k získání fontů používaných v prezentaci. Porovnejte oba výsledky a najděte fonty, které jsou nezbytné pro vykreslení, ale nejsou vloženy.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když stačí uložená metadata dokumentu, přečtěte [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) přes [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). To je vhodné pro lehký inventář. Pokud byla prezentace v paměti upravena, uložená metadata mohou chybět nebo být zastaralá; v takovém případě projděte [Presentation::get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slides/) a zkontrolujte každého snímku metodou [Slide::get_Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/get_hidden/).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation::get_SlideSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slidesize/). Prohlédněte si [ISlideSize::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_size/) a [ISlideSize::get_Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/get_orientation/) a porovnejte aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/) a prozkoumejte [ChartData::get_DataSourceType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Pro externí sešit přečtěte [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Typ zdroje a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdrojů.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Projděte [Presentation::get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slides/) a každou kolekci [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_shapes/). Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako indikátory a změřte reprezentativní render nebo export, než označíte snímek za potvrzený výkonový úzký profil.
---
title: Převod PPT na PPTX v C++
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/cpp/convert-ppt-to-pptx/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Převod starších souborů PPT na PPTX v C++ pomocí Aspose.Slides. Obsahuje ukázky C++ pro převod jednoho souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides for C++ může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po konverzi.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), poté zavolejte [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) s [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/). Uvolněte prezentaci, když ji již nepotřebujete, aby se uvolnily její prostředky.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Přípona souboru sama o sobě nevybírá výstupní formát; argument [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) to dělá. Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze nezastaví zbytek dávky.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Pro produkční úlohy zaznamenejte úplnou výjimku, rozhodněte, zda lze existující výstupní soubor přepsat, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Password-Protected Presentations](/slides/cs/cpp/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, mastery, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nepředstavují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Běžný soubor PPTX není formát s podporou maker, takže použijte vhodný pracovní postup s podporou maker, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, ve kterém bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a prověřte klíčové počty snímků a jejich obsah, poté porovnejte jeho vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Používejte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo ukládána ve formátu, který je snazší prozkoumat a obnovit než starý binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/slides/cs/cpp/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte C++ API.

## **Související články**

- [Uložení prezentací v C++](/slides/cs/cpp/save-presentation/)
- [Podporované formáty souborů](/slides/cs/cpp/supported-file-formats/)
- [Otevření prezentací v C++](/slides/cs/cpp/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides for C++ načítá a ukládá soubory prezentací bez potřeby Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načtení.

**Mám po konverzi smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX ve prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.
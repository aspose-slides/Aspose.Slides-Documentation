---
title: Převod PPT na PPTX v C++
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/cpp/convert-ppt-to-pptx/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v C++ pomocí Aspose.Slides. Obsahuje příklady v C++ pro převod jednotlivých souborů i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro C++ dokáže načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po převodu.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) , poté zavolejte [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) s argumentem [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) . Uvolněte prezentaci, když již není potřeba, aby se uvolnily její prostředky.

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

Přípona souboru sama o sobě nevybírá výstupní formát; argument [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) to provádí. Udržujte vstupní a výstupní cesty odlišné, pokud potřebujete zachovat originální soubor PPT.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže jeden selhaný převod nezastaví zbytek dávky.

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

Pro produkční úlohy zaznamenejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez potřebného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání převodu. Viz [Prezentace chráněné heslem](/cpp/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Převod obvykle zachovává snímky, hlavní šablony, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nevyjadřují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Prostý soubor PPTX není formát podporující makra, proto použijte vhodný workflow podporující makra, pokud musí být VBA dostupné. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

Pro důležité dokumenty znovu programově otevřete vygenerovaný PPTX a zkontrolujte klíčové počty snímků a obsah, poté porovnejte vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

PPTX použijte, pokud bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo uložena ve formátu, který je snazší prozkoumat a obnovit než starší binární PPT. Uchovávejte originální PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Převod prezentací do více formátů](/cpp/convert-presentation/) místo předpokladu, že všechny cíle zachovávají editovatelné funkce PowerPointu.

## **Online konvertor**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT na PPTX konvertor](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované převody, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte C++ API.

## **Související články**

- [Uložit prezentace v C++](/cpp/save-presentation/)
- [Podporované formáty souborů](/cpp/supported-file-formats/)
- [Otevřít prezentace v C++](/cpp/open-presentation/)

## **FAQ**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro C++ načítá a ukládá soubory prezentací bez potřeby Microsoft PowerPoint.

**Zachová převod PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načtení.

**Mám po převodu smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii v případě, že starší funkce převádí jinak.
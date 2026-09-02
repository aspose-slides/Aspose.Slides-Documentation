---
title: Převést prezentace PowerPoint do XML v C++
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/cpp/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint do XML
- převést prezentaci do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- PowerPoint XML Presentation
- SaveFormat::Xml
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- C++
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v C++ pomocí Aspose.Slides for C++."
---
## **Přehled**

Aspose.Slides for C++ dokáže převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, řešení problémů s vygenerovanými dokumenty, porovnávání výstupu v automatizovaných testech nebo integraci do pracovního postupu, který konzumuje XML místo balíčku prezentace.

Použijte metodu [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) s hodnotou `Xml` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako je `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prohlédněte si samotný balíček PPTX.
{{% /alert %}}

## **Převést prezentaci na XML soubor**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a pak předáte výstupní cestu a `SaveFormat::Xml` metodě [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/). Zdroj může být v jakémkoli formátu prezentace podporovaném pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX na XML soubor:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Zapsat výstup XML do proudu**

Použijte přetížení proudu metody [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) v případě, že XML musí zůstat v paměti nebo být předáno jiné komponentě, například webové službě, poskytovateli úložiště nebo XML zpracovatelskému potrubí. Následující příklad zapíše výsledek do [MemoryStream](https://reference.aspose.com/slides/cs/cpp/system.io/memorystream/) a přetočí jej pro následné čtení:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Předejte xmlStream dalšímu komponentu v pracovním postupu.
```

## **Porovnat XML s formáty prezentací a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentace | Kontrola struktury, řešení problémů, porovnání vygenerovaného výstupu a integrace založená na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozložením nebo více‑stránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a obrazová aktiva |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje XML data prezentace, nikoli vykreslení snímků jako stránek nebo vizuálních aktiv. Tabulka [supported file formats](/slides/cs/cpp/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, pokud pracovní postup musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat::Xml` totéž jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat::Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytváření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/). Například použijte [MemoryStream](https://reference.aspose.com/slides/cs/cpp/system.io/memorystream/) pro zpracování v paměti.

**Může Aspose.Slides načíst exportovaný XML soubor znovu?**

Ne. PowerPoint XML Presentation je v současnosti podporováno pouze pro ukládání, nikoli pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, pokud je vyžadována obousměrná editace.

**Převod XML vykresluje každý snímek jako stránku nebo obrázek?**

Ne. Převod XML zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, nebo pro jednotlivé obrázky snímků PNG, JPEG a SVG.
---
title: Komprimovat prezentace
description: Zmenšit velikost prezentace kompresí obrázků a odstraněním nepoužívaného obsahu.
type: docs
url: /cs/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operace
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Přehled**

Komprimujte obrázky, odstraňte oříznuté části obrázků, když již nejsou potřeba, a vyberte nastavení komprese prezentace před uložením. To je užitečné pro prezentace s velkými fotografiemi nebo opakovanými médii. Ušetřená velikost závisí na obsahu a nastaveních, které zvolíte.

## **Příklad použití**

Tento příklad v C# načte `input.pptx`, zkomprimuje prezentaci a uloží ji jako `compressed.pptx`.

Používejte Aspose.Slides pro .NET 26.11 nebo novější. Pro nastavení viz [Instalace Aspose.Slides pro .NET](/slides/cs/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

### **Jedná se o jediné nastavení optimalizace celého souboru?**

Aspose.Slides for .NET 26.11 přidává [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), který kombinuje odstraňování nepoužívaných rozvržení/mistrů, subsetting vložených písem a kompresi obrázků na 150 DPI. Trvale odstraňuje oříznuté části obrázků. Pro zpracování pouze obrázků použijte [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); pro jemnější kontrolu viz [příklad komprese jednotlivých obrázků](/slides/cs/net/examples/optimization-batch/compression/). Tyto nové pomocné funkce jsou specifické pro uvedenou verzi .NET; pro jiné SDK zkontrolujte příslušný průvodce.

### **Mění komprese obrázků editovatelný text nebo grafy?**

Kompresí obrázků se cílí na data obrázku, ne na editovatelný text ani data grafu. Zkontrolujte obrázky, protože jejich změna velikosti nebo opětovná komprese může snížit jejich detail.

### **Jak si mám zvolit rozlišení obrázků v prezentaci?**

Zvolte cílové rozlišení podle velikosti zobrazovaného obrázku a zamýšleného použití na obrazovce nebo v tisku. Uchovejte vyšší rozlišení pro velké displeje, tisk a detailní diagramy a porovnejte výsledný výstup před tím, než původ zahodíte.

## **Průvodci**

- [Komprese celé prezentace v .NET](/slides/cs/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimalizace správy obrázků v prezentacích v .NET](/slides/cs/net/image/)

Related feature: [Odstranění nepoužívaných mistrů, rozvržení a médií](/slides/cs/features/remove-unused-content/).

## **Spustitelné .NET příklady**

- [Zmenšení velikosti prezentace](/slides/cs/net/examples/optimization-batch/compression/)
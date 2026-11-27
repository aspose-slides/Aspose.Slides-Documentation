---
title: Komprimovat prezentace
description: Snížit velikost prezentace kompresí obrázků a odstraněním nepoužitého obsahu.
type: docs
url: /cs/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Přehled**

Komprimujte obrázky, odstraňte oříznuté oblasti obrázků, když již nejsou potřeba, a vyberte nastavení komprese prezentace před uložením. To je užitečné pro prezentace s velkými fotografiemi nebo opakovanými médii. Uložené množství závisí na obsahu a na nastaveních, které zvolíte.

## **Příklad použití**

Tento příklad v C# načte `input.pptx`, komprimuje prezentaci a uloží ji jako `compressed.pptx`.

Použijte Aspose.Slides pro .NET 26.11 nebo novější. Pro nastavení viz [Instalace Aspose.Slides pro .NET](/slides/cs/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Obrázky se stejným měřítkem před a po kompresi, následované měřenými pruhy velikosti souboru PPTX a uloženými rozměry obrázku.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Měřeno na jedné syntetické testovací mřížce: 584 030 → 128 323 bajtů. Oba rendery používají stejné měřítko a rámec 252 × 336 bodů. Komprese odstraňuje oříznuté okraje a snižuje uložený obrázek na 525 × 700 pixelů; úspora velikosti závisí na vstupu.*
<!-- visual-explanation:compress-presentations:end -->

## **Často kladené otázky**

### **Jedná se o jediné přepnutí optimalizace celého souboru?**

Aspose.Slides pro .NET 26.11 přidává [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), který kombinuje odstranění nepoužívaných rozvržení/mistrov, podmnožinu vložených fontů a kompresi obrázků s rozlišením 150 DPI. Trvale odstraňuje oříznuté oblasti obrázků. Pro zpracování pouze obrázků použijte [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); pro jemnější kontrolu viz [příklad komprese jednotlivých obrázků](/slides/cs/net/examples/optimization-batch/compression/). Od verze 26.11 je stejné volání pro celou prezentaci dostupné také v Javě, Node.js přes Java, Pythonu přes .NET a C++. Příklad a odkazy na této stránce jsou pro .NET.

### **Mění komprese obrázků editovatelný text nebo grafy?**

Komprese obrázků cílí na data obrázku, nikoli na editovatelný text nebo data grafu. Přezkoumejte obrázky, protože změna velikosti nebo opětovná komprese může snížit jejich detail.

### **Jak si mám vybrat rozlišení pro obrázky v prezentaci?**

Vyberte cíl na základě velikosti zobrazeného obrázku a zamýšleného použití na obrazovce nebo při tisku. Zachovejte vyšší rozlišení pro velké displeje, tisk a podrobné diagramy a porovnejte výstup před zahodením originálu.

## **Návody**

- [Komprimovat celou prezentaci v .NET](/slides/cs/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimalizovat správu obrázků v prezentacích v .NET](/slides/cs/net/image/)

Související funkce: [Odstranit nepoužívané mistry, rozvržení a média](/slides/cs/features/remove-unused-content/).

## Spustitelné .NET příklady

- [Zmenšit velikost prezentace](/slides/cs/net/examples/optimization-batch/compression/)
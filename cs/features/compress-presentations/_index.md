---
title: Komprimovat prezentace
description: Snížit velikost prezentace pomocí komprese obrázků a uložit nastavení.
type: docs
url: /cs/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operace
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Přehled**

Komprimujte obrázky, odstraňte oříznuté části obrázků, když již nejsou potřeba, a vyberte nastavení komprese prezentace před uložením. To je užitečné pro prezentace s velkými fotografiemi nebo opakovaným médiím. Ušetřená velikost závisí na obsahu a nastaveních, které zvolíte.

## **Příklad použití**

Tento příklad v C# používá Aspose.Slides pro .NET. Viditelně vytvoří gradientní PNG o rozměrech 1600 × 900 pixelů, vloží jej do malého obrázkového rámce a uloží *before.pptx*. Poté komprimuje tento obrázek na cílové rozlišení 96 DPI a uloží *compressed.pptx*. Porovnejte velikosti souborů a náhledy: úspory závisí na vstupním obrázku a zobrazované velikosti.

Pro nastavení viz [Instalace Aspose.Slides pro .NET](/slides/cs/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Často kladené otázky**

### **Je to jediný přepínač optimalizace celého souboru?**

Aspose.Slides pro .NET 26.11 přidává [Compress.CompressPresentation](/slides/cs/net/low-code-presentation-operations/#compress-the-whole-presentation), který kombinuje odstranění nepoužívaných rozvržení/mistrov, podmnožování vložených písem a kompresi obrázků na 150 DPI. Trvale odstraňuje oříznuté oblasti obrázků. Pro zpracování pouze obrázků použijte Compress.CompressImages; pro jemnější řízení zachovejte výše uvedený postup per obrázek. Tito noví pomocníci jsou specifické pro uvedenou verzi .NET; pro jiné SDK zkontrolujte odpovídající průvodce.

### **Mění komprese obrázků editovatelný text nebo grafy?**

Komprese obrázků cílí na data obrázku, nikoli na editovatelný text nebo data grafů. Prohlédněte si obrázky, protože změna velikosti nebo recomprese může snížit jejich detail.

### **Jak mám zvolit rozlišení pro obrázky v prezentaci?**

Zvolte cíl na základě zobrazované velikosti obrázku a zamýšleného použití na obrazovce nebo tisku. Zachovejte vyšší rozlišení pro velké displeje, tisk a detailní diagramy a porovnejte výstup před zahoděním originálu.

## **Průvodci**

- [Optimalizace správy obrázků v prezentacích v .NET](/slides/cs/net/image/)

Related feature: [Odstranění nepoužívaných mistrů, rozvržení a médií](/slides/cs/features/remove-unused-content/).

## **Spustitelné .NET příklady**

- [Zmenšení velikosti prezentace](/slides/cs/net/examples/optimization-batch/compression/)
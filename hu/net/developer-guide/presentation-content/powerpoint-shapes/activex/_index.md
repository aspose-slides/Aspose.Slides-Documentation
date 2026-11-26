---
title: ActiveX vezérlők kezelése PowerPoint prezentációkban .NET környezetben
linktitle: ActiveX
type: docs
weight: 80
url: /hu/net/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Szerkessze az ActiveX szövegdobozokat és gombokat, frissítse a vezérlő előnézeteket, és használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

Az ActiveX vezérlők interaktív elemeket adnak a PowerPoint diákhoz, például szövegdobozokat, parancsgombokat és médiaszereplőket. Az Aspose.Slides for .NET a dia vezérlőit a [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) révén teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, áthelyezéséhez a dián vagy eltávolításához.

## **Az ActiveX vezérlők listázása és tárolt tulajdonságaik**

Egy ismeretlen sablon megvizsgálásához nyissa meg olvasásra, és iteráljon végig a dia minden vezérlőjén. A példa jelentést készít a dia számáról, a vezérlő nevéről, a [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) címkéről, valamint a [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) kulcs‑érték párokról. A prezentációt úgy olvassa be, hogy nem aktiválja a vezérlőket, nem hív meg eseményeket vagy makrókat, nem változtatja meg az értékeket, és nem menti a fájlt.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

A `ActiveX.pptm` kiválasztott kimenete egy szövegdobozt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Üres tulajdonsággyűjtemény `[]`ként jelenik meg. Az olyan vezérlőknél, amelyek bináris tárolást használnak, a `Properties` `null` értéket adhat vissza, ami a `Properties unavailable` üzenettel jelenik meg. Ha csak a nevekre van szükség, a `null` ellenőrzés után használja a [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) metódust. A jelentés felsorolja a prezentációban elérhető tulajdonságokat. Egy vezérlő futásidőben további tulajdonságokat is támogathat.

## **ActiveX vezérlők módosítása**

A példa egy makrókkal engedélyezett prezentációt vár, amelyen az első dián egy `TextBox1` nevű szövegdoboz és egy `CommandButton1` nevű parancsgomb található. A [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) segítségével módosítja a szövegdoboz értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete is, amelyet a PowerPoint az aktiválás előtt megjeleníthet. Adjon meg egy PNG‑t minden vezérlőhöz, amely az új szöveget és megjelenést mutatja. A példa ezeket a képeket az [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) segítségével rendeli hozzá.

A példa az első dián lévő összes vezérlőt 100 ponttal lefelé mozgatja a [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) módosításával. A szerkesztett prezentációt PPTM formátumban menti, majd az [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) használatával elment egy második példányt, amelyből az összes ActiveX vezérlő el lett távolítva az adott diáról.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```
## **ActiveX médiaplayer vezérlő hozzáadása**

Egy konfigurált Windows Media Player vezérlő újrahasználatához kezdjen egy olyan sablonnal, amelynek első diája egy `WindowsMediaPlayer1` nevű lejátszót tartalmaz. Az [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) lemásolja az egész diát egy új prezentációba. A példa beállítja a lejátszó `URL`‑jét a [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) segítségével, és a klónozott diát az egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon olyan útvonalat, amelyhez a lejátszó a lejátszás során hozzáférhet.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```
## **GYIK**

**Meg tudja őrizni az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes beolvasni és menteni a vezérlőket, beleértve azok tulajdonságait és pozícióit, anélkül, hogy aktiválná azokat.

**Hogyan különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára, hogy interakcióba lépjenek a diával, például szöveget adjanak meg vagy gombot nyomjanak meg. Egy [OLE objektum](/slides/hu/net/manage-ole/) lehetővé teszi, hogy a dia tartalmazzon vagy hivatkozzon egy másik alkalmazás által kezelt tartalomra, például egy Excel munkalapra.

**Kiváltják-e az ActiveX események a VBA makrókat, miután a prezentációt az Aspose.Slides‑szel mentem?**

Mentse a prezentációt makrókkal engedélyezett formátumban, például PPTM‑ben, hogy megőrizze a VBA projektet. A Windows PowerPoint képes végrehajtani a meglévő eseménykezelőket, ha a biztonsági beállítások engedélyezik az ActiveX vezérlőket és a makrókat egyaránt.
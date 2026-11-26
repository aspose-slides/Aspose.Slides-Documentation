---
title: Správa ActiveX ovládacích prvků v prezentacích v .NET
linktitle: ActiveX
type: docs
weight: 80
url: /cs/net/activex/
keywords:
- ActiveX
- ovládací prvek ActiveX
- spravovat ActiveX
- přidat ActiveX
- upravit ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint pomocí Aspose.Slides pro .NET."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní elementy, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides pro .NET zpřístupňuje ovládací prvky snímku prostřednictvím [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunutí na snímku nebo jeho odstranění.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a projděte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) a každý pár klíč‑hodnota v [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Prezentaci načítá bez aktivace ovládacích prvků, spouštění událostí nebo maker, měnění hodnot či ukládání souboru.

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

Vybraný výstup ze `ActiveX.pptm` ukazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazuje jako `[]`. Pro ovládací prvky, které používají binární úložiště, může `Properties` vracet `null`, což je zobrazeno jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) po kontrole na `null`. Zpráva vypisuje vlastnosti dostupné v prezentaci. Ovládací prvek může za běhu podporovat další vlastnosti.

## **Upravit ActiveX ovládací prvky**

Příklad očekává prezentaci s povolenými makry, ve které je na prvním snímku textové pole pojmenované `TextBox1` a tlačítko příkazu pojmenované `CommandButton1`. Používá [kolekci vlastností ovládacího prvku](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) ke změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte pro každý ovládací prvek PNG ukazující jeho aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Příklad posune všechny ovládací prvky na prvním snímku dolů o 100 bodů změnou jejich [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Uloží upravenou prezentaci ve formátu PPTM a poté použije [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) k uložení druhé kopie, ve které jsou z daného snímku odstraněny všechny ActiveX ovládací prvky.

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

## **Přidat ActiveX ovládací prvek Media Player**

Chcete‑li znovu použít nakonfigurovaný ovládací prvek Windows Media Player, začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) zkopíruje celý snímek do nové prezentace. Příklad nastaví přehrávači `URL` v jeho [kolekci vlastností](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) a uloží zklonovaný snímek jako jediný snímek ve výstupu. Video zůstává externí, proto zvolte cestu, ke které má přehrávač během přehrávání přístup.

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

## **Často kladené otázky**

**Může Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se liší ActiveX ovládací prvky od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadáním textu nebo kliknutím na tlačítko. [OLE objekt](/slides/cs/net/manage-ole/) umožňuje, aby snímek obsahoval nebo odkazoval na obsah spravovaný jinou aplikací, jako je například list Excelu.

**Spustí se události ActiveX stále VBA makra po uložení prezentace pomocí Aspose.Slides?**

Uložte prezentaci v formátu s povolenými makry, například PPTM, aby byl zachován její VBA projekt. PowerPoint pro Windows může spustit existující obslužné rutiny událostí, pokud nastavení zabezpečení povolí jak ActiveX ovládací prvky, tak makra.
---
title: Správa uzlů tvaru SmartArt v prezentacích v .NET
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/net/manage-smartart-shape-node/
keywords:
- uzel SmartArt
- poduzel
- přidat uzel
- pozice uzlu
- přístup k uzlu
- odebrat uzel
- vlastní pozice
- asistenční uzel
- výplňový formát
- vykreslit uzel
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v souborech PPT a PPTX pomocí Aspose.Slides pro .NET. Získejte jasné ukázky kódu a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je organizována pomocí uzlů, které obsahují text a určují strukturu diagramu. Aspose.Slides umožňuje programově pracovat s těmito uzly SmartArt: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak uzly odebrat, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný, upravit pozici, velikost a otočení tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vygenerovat miniaturu pro poduzel SmartArt.

## **Přidání uzlu SmartArt**
Aspose.Slides pro .NET poskytuje nejjednodušší API pro správu tvarů SmartArt nejužitečnějším způsobem. Následující ukázkový kód pomůže přidat uzel a poduzel do tvaru SmartArt.

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Přidejte nový uzel do kolekce NodeCollection tvaru SmartArt a nastavte text v TextFrame.
- Nyní přidejte poduzel do nově přidaného uzlu SmartArt a nastavte text v TextFrame.
- Uložte prezentaci.

```c#
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AddNodes.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Zkontrolujte, zda je tvar typu SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Přetypujte tvar na SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Přidání nového uzlu SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Přidání textu
        TemNode.TextFrame.Text = "Test";

        // Přidání nového poduzlu do nadřazeného uzlu. Bude přidán na konec kolekce
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Přidání textu
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Ukládání prezentace
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Přidání uzlu SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu je vysvětleno, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na určenou pozici.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Přidejte do přístupu snímku SmartArt tvar typu StackedList.
- Přistupte k prvnímu uzlu v přidaném tvaru SmartArt.
- Nyní přidejte poduzel pro vybraný uzel na pozici 2 a nastavte jeho text.
- Uložte prezentaci.

```c#
// Vytvoření instance prezentace
Presentation pres = new Presentation();

// Přístup k snímku prezentace
ISlide slide = pres.Slides[0];

// Přidání Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Přístup k uzlu SmartArt s indexem 0
ISmartArtNode node = smart.AllNodes[0];

// Přidání nového poduzlu na pozici 2 v nadřazeném uzlu
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Přidat text
chNode.TextFrame.Text = "Sample Text Added";

// Uložit prezentaci
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Přístup k uzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že LayoutType SmartArt nelze měnit, protože je jen pro čtení a nastavený je pouze při vytvoření tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Přistupte a zobrazte informace jako pozice uzlu SmartArt, úroveň a Text.

  ```c#
  // Načtěte požadovanou prezentaci
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Procházejte všechny tvary na prvním snímku
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Zkontrolujte, zda je tvar typu SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Přetypujte tvar na SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Procházejte všechny uzly uvnitř SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Přístup k uzlu SmartArt s indexem i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Výpis parametrů uzlu SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **Přístup k poduzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k poduzlům patřícím k příslušným uzlům tvaru SmartArt.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArtEx.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Pro každý vybraný uzel SmartArt projděte všechny poduzly v daném uzlu.
- Přistupte a zobrazte informace jako pozice poduzlu, úroveň a Text.

```c#
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Procházejte všechny tvary na prvním snímku
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Zkontrolujte, zda je tvar typu SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Přetypujte tvar na SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Procházejte všechny uzly uvnitř SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Přístup k uzlu SmartArt s indexem i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Procházení poduzlů v uzlu SmartArt na indexu i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Přístup k poduzlu v uzlu SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Výpis parametrů poduzlu SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíme přistupovat k poduzlům na konkrétní pozici, které patří k příslušným uzlům tvaru SmartArt.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Přidejte SmartArt tvar typu StackedList.
- Přistupte k přidanému tvaru SmartArt.
- Přistupte k uzlu s indexem 0 v přístupném tvaru SmartArt.
- Nyní pomocí metody GetNodeByPosition() přistupte k poduzlu na pozici 1 v přístupném uzlu SmartArt.
- Přistupte a zobrazte informace jako pozice poduzlu, úroveň a Text.

```c#
// Vytvořte instanci prezentace
Presentation pres = new Presentation();

// Přístup k prvnímu snímku
ISlide slide = pres.Slides[0];

// Přidání tvaru SmartArt na první snímek
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Přístup k uzlu SmartArt s indexem 0
ISmartArtNode node = smart.AllNodes[0];

// Přístup k poduzlu na pozici 1 v nadřazeném uzlu
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Výpis parametrů poduzlu SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Odebrání uzlu SmartArt**
V tomto příkladu se naučíme odebrat uzly uvnitř tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Zkontrolujte, zda má SmartArt více než 0 uzlů.
- Vyberte uzel SmartArt, který má být smazán.
- Nyní odeberte vybraný uzel pomocí metody RemoveNode() a uložte prezentaci.

```c#
// Načtěte požadovanou prezentaci
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Procházejte všechny tvary na prvním snímku
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape is ISmartArt)
        {
            // Přetypujte tvar na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Přístup k uzlu SmartArt s indexem 0
                ISmartArtNode node = smart.AllNodes[0];

                // Odstranění vybraného uzlu
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Uložit prezentaci
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Odebrání uzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíme odebrat uzly uvnitř tvaru SmartArt na konkrétní pozici.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Vyberte uzel tvaru SmartArt s indexem 0.
- Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
- Nyní odeberte uzel na pozici 1 pomocí metody RemoveNodeByPosition().
- Uložte prezentaci.

```c#
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Procházejte všechny tvary na prvním snímku
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Zkontrolujte, zda je tvar typu SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Přetypujte tvar na SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Přístup k uzlu SmartArt s indexem 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Odstranění poduzlu na pozici 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Uložit prezentaci
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Nastavení vlastní pozice poduzlu v objektu SmartArt**
Aspose.Slides pro .NET nyní podporuje nastavení vlastností X a Y tvaru SmartArtShape. Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a otočení tvaru SmartArtShape; také poznamenáváme, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů.

```c#
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Přesuňte tvar SmartArt na novou pozici
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Změňte šířku tvaru SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Změňte výšku tvaru SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Změňte rotaci tvaru SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Kontrola asistenčního uzlu**
V následujícím ukázkovém kódu zjistíme, jak identifikovat asistenční uzly v kolekci uzlů SmartArt a měnit je.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na druhý snímek pomocí jeho Indexu.
- Projděte všechny tvary na prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArtEx.
- Projděte všechny uzly uvnitř tvaru SmartArt a zjistěte, zda jsou asistenčními uzly.
- Změňte stav asistenčního uzlu na běžný uzel.
- Uložte prezentaci.

```c#
// Vytvoření instance prezentace
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Procházení všech tvarů na prvním snímku
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Přetypujte tvar na SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Procházení všech uzlů tvaru SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Zkontrolujte, zda je uzel asistenční
                if (node.IsAssistant)
                {
                    // Nastavení asistenčního uzlu na false a jeho převod na běžný uzel
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Uložit prezentaci
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Nastavení výplňového formátu uzlu**
Aspose.Slides pro .NET umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňové formáty. Tento článek vysvětluje, jak vytvářet a přistupovat k tvarům SmartArt a nastavit jejich výplňový formát pomocí Aspose.Slides pro .NET.

Postupujte podle následujících kroků:

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte tvar SmartArt nastavením jeho LayoutType.
- Nastavte FillFormat pro uzly tvaru SmartArt.
- Uložte upravenou prezentaci jako soubor PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Přístup k snímku
    ISlide slide = presentation.Slides[0];

    // Přidání tvaru SmartArt a uzlů
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Nastavení výplňové barvy uzlu
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Ukládání prezentace
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Generování miniatury poduzlu SmartArt**
Vývojáři mohou vygenerovat miniaturu poduzlu SmartArt podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`, která představuje soubor PPTX.
2. Přidejte SmartArt.
3. Získejte odkaz na uzel pomocí jeho Indexu.
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu.

Příklad níže generuje miniaturu poduzlu SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Často kladené otázky**

**Je animace SmartArt podporována?**

Ano. SmartArt je zpracován jako běžný tvar, takže můžete [použít standardní animace](/slides/cs/net/shape-animation/) (vstup, výstup, zdůraznění, trajektorie pohybu) a upravit časování. Po potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak spolehlivě najít konkrétní SmartArt na snímku, když jeho interní ID není známé?**

Použijte a hledejte podle [alternativního textu](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/alternativetext/). Nastavením jedinečného AltTextu na SmartArt jej můžete programově najít bez spoléhání se na interní identifikátory.

**Zachová se vzhled SmartArt při převodu prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/net/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy i efekty.

**Mohu získat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete renderovat tvar SmartArt do [rastrů formátů](/slides/cs/net/aspose.slides/shape/getimage/) nebo do [SVG](/slides/cs/net/aspose.slides/shape/writeassvg/) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy či použití na webu.
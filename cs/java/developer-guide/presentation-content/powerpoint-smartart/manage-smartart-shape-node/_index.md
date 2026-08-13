---
title: Správa uzlů tvaru SmartArt v prezentacích pomocí Javy
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/java/manage-smartart-shape-node/
keywords:
- uzel SmartArt
- poduzel
- přidat uzel
- pozice uzlu
- přístup k uzlu
- odstranit uzel
- vlastní pozice
- asistenční uzel
- formát výplně
- vykreslit uzel
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v PPT a PPTX pomocí Aspose.Slides pro Javu. Získejte jasné ukázky kódu a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je uspořádána pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvaru SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a otáčení tvarů uzlů SmartArt, nastavit formáty výplně uzlů a vygenerovat miniaturu obrázku pro poduzel SmartArt.

## **Přidání uzlu SmartArt**
Aspose.Slides for Java poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Níže uvedený ukázkový kód pomůže přidat uzel a poduzel do tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. [Přidejte nový uzel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) do tvaru SmartArt [**NodeCollection**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt#getAllNodes--) a nastavte text v TextFrame.
6. Nyní [přidejte](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**poduzel**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getChildNodes--) do nově přidaného [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) uzlu a nastavte text v TextFrame.
7. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Projděte všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Přetypujte tvar na SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Přidání nového uzlu SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Přidání textu
            TemNode.getTextFrame().setText("Test");
    
            // Přidání nového poduzlu do nadřazeného uzlu. Bude přidán na konci kolekce
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Přidání textu
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Uložení prezentace
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání uzlu SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu vysvětlujeme, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy Presentation.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Přidejte tvar [**StackedList**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType#StackedList) typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt) do přístupového snímku.
4. Přistupte k prvnímu uzlu v přidaném tvaru SmartArt.
5. Nyní přidejte [**poduzel**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pro vybraný [**uzel**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtNode) na pozici 2 a nastavte jeho text.
6. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Přístup k uzlu SmartArt na indexu 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Přidání nového poduzlu na pozici 2 v nadřazeném uzlu
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Přidat text
    chNode.getTextFrame().setText("Sample Text Added");

    // Uložení prezentace
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k uzlu SmartArt**
Níže uvedený ukázkový kód pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že nelze změnit LayoutType SmartArt, protože je pouze pro čtení a nastavuje se pouze při přidání tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. Projděte všechny [**uzly**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Přistupte a zobrazte informace jako pozice uzlu SmartArt, úroveň a text.

```java
import com.aspose.slides.*;

// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Získání prvního snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházení všech tvarů v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrola, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypování tvaru na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Procházení všech uzlů uvnitř SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Přístup k uzlu SmartArt na indexu i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Výpis parametrů uzlu SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k poduzlu SmartArt**
Níže uvedený ukázkový kód pomůže přistupovat k poduzlům patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. Projděte všechny [**uzly**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Pro každý vybraný uzel tvaru SmartArt [**Node**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtNode) projděte všechny [**poduzly**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtNode#getChildNodes--) uvnitř konkrétního uzlu.
7. Přistupte a zobrazte informace jako pozice [**poduzlu**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , úroveň a text.

```java
import com.aspose.slides.*;

// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Získání prvního snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházení všech tvarů v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrola, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypování tvaru na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Procházení všech uzlů uvnitř SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Přístup k uzlu SmartArt na indexu i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Procházení poduzlů v uzlu SmartArt na indexu i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Přístup k poduzlu v uzlu SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Výpis parametrů poduzlu SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíte přistupovat k poduzlům na konkrétní pozici, patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Přidejte tvar SmartArt typu [**StackedList**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType#StackedList).
4. Přistupte k přidanému tvaru SmartArt.
5. Přistupte k uzlu s indexem 0 ve získaném tvaru SmartArt.
6. Nyní přistupte k [**poduzlu**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getChildNodes--) na pozici 1 pro přístupový uzel SmartArt pomocí metody **get_Item()**.
7. Přistupte a zobrazte informace jako pozice [**poduzlu**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , úroveň a text.

```java
import com.aspose.slides.*;

// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidání tvaru SmartArt do prvního snímku
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Přístup k uzlu SmartArt na indexu 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Přístup k poduzlu na pozici 1 v nadřazeném uzlu
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Výpis parametrů poduzlu SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění uzlu SmartArt**
V tomto příkladu se naučíte odstraňovat uzly uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. Zkontrolujte, zda má [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) více než 0 uzlů.
6. Vyberte uzel SmartArt, který má být smazán.
7. Nyní odstraňte vybraný uzel pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
8. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projděte všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypujte tvar na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Přístup k uzlu SmartArt na indexu 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Odstranění vybraného uzlu
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Uložení prezentace
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění uzlu SmartArt z konkrétní pozice**
V tomto příkladu se naučíte odstraňovat uzly uvnitř tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. Vyberte uzel tvaru SmartArt s indexem 0.
6. Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
7. Nyní odstraňte uzel na **pozici 1** pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
8. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projděte všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Přetypujte tvar na SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Přístup k uzlu SmartArt na indexu 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Odstranění poduzlu na pozici 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Uložení prezentace
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení vlastní pozice pro poduzel v objektu SmartArt**
Nyní Aspose.Slides pro Java podporuje nastavení vlastností [SmartArtShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#setX-float-) a [Y](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#setY-float-). Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a otáčení SmartArtShape; také si všimněte, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů. S nastavením vlastní pozice může uživatel uzly nastavit dle požadavků.

```java
import com.aspose.slides.*;

// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Přesunutí tvaru SmartArt na novou pozici
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Změna šířky tvaru SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Změna výšky tvaru SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Změna rotace tvaru SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Kontrola asistenčního uzlu**
{{% alert color="info" %}} 

V tomto článku dále prozkoumáme funkce tvarů SmartArt přidaných do snímků prezentace programově pomocí Aspose.Slides pro Java.

{{% /alert %}} 

Pro naše vyšetřování v různých částech tohoto článku použijeme následující zdrojový tvar SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Obrázek: Zdrojový tvar SmartArt na snímku**|

V následujícím ukázkovém kódu prozkoumáme, jak identifikovat **asistenční uzly** v kolekci uzlů SmartArt a jak je měnit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na druhý snímek pomocí jeho indexu.
3. Projděte všechny tvary v první snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt), pokud se jedná o SmartArt.
5. Projděte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou [**asistenční uzly**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtNode#isAssistant--).
6. Změňte stav asistenčního uzlu na normální uzel.
7. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Vytvoření instance prezentace
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Procházení všech tvarů v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kontrola, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypování tvaru na SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Procházení všech uzlů tvaru SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Kontrola, zda je uzel asistenční
                if (node.isAssistant()) 
                {
                    // Nastavení asistenčního uzlu na false a převod na běžný uzel
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Uložení prezentace
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Obrázek: Asistenční uzly změněny v tvaru SmartArt na snímku**|

## **Nastavení výplně uzlu**
Aspose.Slides pro Java umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplň. Tento článek vysvětluje, jak vytvářet a přistupovat k tvarům SmartArt a nastavit jejich výplň pomocí Aspose.Slides pro Java.

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArt) nastavením jeho [**LayoutType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Nastavte [**FillFormat**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getFillFormat--) pro uzly tvaru SmartArt.
5. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidání tvaru SmartArt a uzlů
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Nastavení barvy výplně uzlu
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Uložení prezentace
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření miniatury poduzlu SmartArt**
Vývojáři mohou vytvořit miniaturu poduzlu SmartArt pomocí následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. [Přidejte SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Získejte referenci na uzel pomocí jeho indexu.
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

```java
import com.aspose.slides.*;

// Vytvoření instance třídy Presentation, která představuje soubor PPTX 
Presentation pres = new Presentation();
try {
    // Přidání SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Získání reference na uzel pomocí jeho indexu  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Získání miniatury
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Uložení miniatury
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Je podpora animace SmartArt?
Ano. SmartArt je považován za běžný tvar, takže můžete [použít standardní animace](/slides/cs/java/shape-animation/) (vstupní, výstupní, zdůrazňovací, pohybové cesty) a upravit načasování. V případě potřeby můžete také animovat tvary uvnitř uzlů SmartArt.

### Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?
Přiřaďte a hledejte podle [alternativního textu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getAlternativeText--). Nastavení výrazného AltTextu na SmartArt vám umožní jej programově najít bez spoléhání se na interní identifikátory.

### Zůstane vzhled SmartArt zachován při převodu prezentace do PDF?
Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/java/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy i efekty.

### Můžu získat obrázek celého SmartArt (pro náhledy nebo zprávy)?
Ano. Můžete vykreslit tvar SmartArt do [rasterových formátů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-) nebo do [SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), což poskytuje škálovatelný vektorový výstup vhodný pro miniatury, zprávy nebo použití na webu.
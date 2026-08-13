---
title: Správa uzlů tvaru SmartArt v prezentacích na Androidu
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/androidjava/manage-smartart-shape-node/
keywords:
- Uzel SmartArt
- Poduzel
- Přidat uzel
- Pozice uzlu
- Přístup k uzlu
- Odstranit uzel
- Vlastní pozice
- Asistenční uzel
- Formát výplně
- Vykreslit uzel
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v souborech PPT a PPTX pomocí Aspose.Slides pro Android. Získejte přehledné ukázky kódu v jazyce Java a tipy pro zjednodušení vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je uspořádána pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vytvořit miniaturu obrazu pro uzel SmartArt.

## **Přidat uzel SmartArt**
Aspose.Slides pro Android přes Java poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Následující ukázkový kód vám pomůže přidat uzel a poduzel uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. [Přidat nový uzel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) do tvaru SmartArt [**NodeCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) a nastavte text v TextFrame.
6. Nyní [Přidejte](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Poduzel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) do nově přidaného [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) uzlu a nastavte text v TextFrame.
7. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načíst požadovanou prezentaci
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Projít všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Přetypovat tvar na SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Přidání nového uzlu SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Přidání textu
            TemNode.getTextFrame().setText("Test");
    
            // Přidání nového poduzlu do nadřazeného uzlu. Bude přidán na konec kolekce
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Přidání textu
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Ukládání prezentace
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidat uzel SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu vysvětlujeme, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy Presentation.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) do získaného snímku.
4. Získejte první uzel v přidaném tvaru SmartArt.
5. Nyní přidejte [**Poduzel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pro vybraný [**Uzel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode) na pozici 2 a nastavte jeho text.
6. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidat Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Přístup k uzlu SmartArt na indexu 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Přidání nového poduzlu na pozici 2 v nadřazeném uzlu
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Přidat text
    chNode.getTextFrame().setText("Sample Text Added");

    // Uložit prezentaci
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k uzlu SmartArt**
Následující ukázkový kód vám pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že LayoutType SmartArt je zvolen při přidání tvaru; změna později pomocí **setLayout** přestaví celý diagram, takže pozice a velikosti uzlů, které jste nastavili, jsou přepočítány.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. Projděte všechny [**Uzly**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Přistupte a zobrazte informace jako je pozice uzlu SmartArt, úroveň a Text.

```java
import com.aspose.slides.*;

// Instancovat třídu Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Projít všechny tvary v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Projít všechny uzly uvnitř SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Přístup k uzlu SmartArt na indexu i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Vytisknout parametry uzlu SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k poduzlu SmartArt**
Následující ukázkový kód vám pomůže přistupovat k poduzlům patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. Projděte všechny [**Uzly**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Pro každý vybraný [**Uzel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode) tvaru SmartArt projděte všechny [**Poduzly**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) uvnitř konkrétního uzlu.
7. Přistupte a zobrazte informace jako je pozice [**Poduzlu**], úroveň a Text.

```java
import com.aspose.slides.*;

// Instancovat třídu Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Projít všechny tvary v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Projít všechny uzly uvnitř SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Přístup k uzlu SmartArt na indexu i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Procházet poduzly v uzlu SmartArt na indexu i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Přístup k poduzlu v uzlu SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Vytisknout parametry poduzlu SmartArt
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
V tomto příkladu se naučíme přistupovat k poduzlům na konkrétní pozici patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).
4. Získejte přístup k přidanému tvaru SmartArt.
5. Získejte uzel na indexu 0 pro získaný tvar SmartArt.
6. Nyní přistupte k [**Poduzlu**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) na pozici 1 pro získaný uzel SmartArt pomocí metody **get_Item()**.
7. Přistupte a zobrazte informace jako je pozice [**Poduzlu**], úroveň a Text.

```java
import com.aspose.slides.*;

// Instancovat prezentaci
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
    
    // Vytisknutí parametrů poduzlu SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranit uzel SmartArt**
V tomto příkladu se naučíme odstranit uzly uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. Zkontrolujte, zda má [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) více než 0 uzlů.
6. Vyberte uzel SmartArt, který má být smazán.
7. Nyní odstraňte vybraný uzel pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
8. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načíst požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projít všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
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
    
    // Uložit prezentaci
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranit uzel SmartArt z konkrétní pozice**
V tomto příkladu se naučíme odstranit uzly uvnitř tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. Vyberte uzel tvaru SmartArt na indexu 0.
6. Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
7. Nyní odstraňte uzel na **Pozici 1** pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
8. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Načíst požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projít všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Přetypovat tvar na SmartArt
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
    
    // Uložit prezentaci
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit vlastní pozici pro poduzel v objektu SmartArt**
Nyní Aspose.Slides pro Android přes Java podporuje nastavení vlastností X a Y pro [SmartArtShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtShape). Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a rotaci SmartArtShape; také si všimněte, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů. S vlastními nastaveními pozice může uživatel nastavit uzly podle požadavků.

```java
import com.aspose.slides.*;

// Instancovat třídu Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Přesunout tvar SmartArt do nové pozice
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Změnit šířky tvaru SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Změnit výšku tvaru SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Změnit rotaci tvaru SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Zkontrolovat asistenční uzel**
{{% alert color="info" %}} 

V tomto článku budeme dále zkoumat funkce tvarů SmartArt přidaných do snímků prezentace programově pomocí Aspose.Slides pro Android přes Java.

{{% /alert %}} 

Pro naše zkoumání v různých sekcích tohoto článku použijeme následující zdrojový tvar SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Obrázek: Zdrojový tvar SmartArt na snímku**|

V následujícím ukázkovém kódu budeme zkoumat, jak identifikovat **asistenční uzly** v kolekci uzlů SmartArt a měnit je.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
2. Získejte odkaz na první snímek pomocí jeho Indexu.
3. Projděte všechny tvary v prvním snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a pokud je, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt).
5. Projděte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou **asistenční uzly**.
6. Změňte stav asistenčního uzlu na normální uzel.
7. Uložte prezentaci.

```java
import com.aspose.slides.*;

// Vytvoření instance prezentace
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Projít všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Procházet všechny uzly tvaru SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Zkontrolovat, zda je uzel asistenční
                if (node.isAssistant()) 
                {
                    // Nastavit asistenční uzel na false a učinit ho běžným uzlem
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Uložit prezentaci
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Obrázek: Asistenční uzly změněny v tvaru SmartArt na snímku**|

## **Nastavit výplňový formát uzlu**
Aspose.Slides pro Android přes Java umožňuje přidávat vlastní tvary SmartArt a nastavovat jejich výplňový formát. Tento článek vysvětluje, jak vytvářet a přistupovat k tvarům SmartArt a nastavovat jejich výplňový formát pomocí Aspose.Slides pro Android přes Java.

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) nastavením jeho [**LayoutType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Nastavte [**FillFormat**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getFillFormat--) pro uzly tvaru SmartArt.
5. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancovat prezentaci
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
    
    // Uložit prezentaci
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvořit miniaturu uzlu SmartArt**
Vývojáři mohou vytvořit miniaturu uzlu SmartArt podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Přidejte [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Získejte odkaz na uzel pomocí jeho Indexu.
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

```java
import com.aspose.slides.*;

// Vytvořit instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přidat SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Získat odkaz na uzel pomocí jeho indexu  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Získat miniaturu
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Uložit miniaturu
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

### Je animace SmartArt podporována?
Ano. SmartArt je považována za běžný tvar, takže můžete [aplikovat standardní animace](/slides/cs/androidjava/shape-animation/) (vstupní, výstupní, zdůrazňující, pohybové cesty) a upravit časování. Také můžete animovat tvary uvnitř uzlů SmartArt, když je to potřeba.

### Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?
Přiřaďte a vyhledejte pomocí [alternativního textu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getAlternativeText--). Nastavení výrazného AltTextu na SmartArt vám umožní jej programově najít bez spoléhaní na interní identifikátory.

### Zůstane vzhled SmartArt zachován při převodu prezentace do PDF?
Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy a efekty.

### Mohu extrahovat obrázek celého SmartArt (pro náhledy nebo zprávy)?
Ano. Můžete vykreslit tvar SmartArt do [rasterových formátů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) nebo do [SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo webové použití.
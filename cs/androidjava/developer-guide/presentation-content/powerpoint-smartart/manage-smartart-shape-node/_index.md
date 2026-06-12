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
- Renderovat uzel
- PowerPoint
- Prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v PPT a PPTX pomocí Aspose.Slides pro Android. Získejte jasné ukázky kódu v jazyce Java a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je organizována pomocí uzlů, které obsahují text a určují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlu SmartArt, nastavit formáty výplně uzlu a vygenerovat miniaturu pro poduzel SmartArt.

## **Přidání uzlu SmartArt**
Aspose.Slides for Android via Java poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Následující ukázkový kód pomůže přidat uzel a poduzel uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. [Add a new Node](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) v kolekci tvaru SmartArt [**NodeCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) a nastavte text v TextFrame.
6. Nyní [Add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) v nově přidaném uzlu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a nastavte text v TextFrame.
7. Uložte prezentaci.

```java
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Projděte všechny tvary na prvním snímku
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

## **Přidání uzlu SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu vysvětlujeme, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na specifické pozici.

1. Vytvořte instanci třídy Presentation.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Přidejte tvar [**StackedList**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt) na přístupném snímku.
4. Přistupte k prvnímu uzlu v přidaném tvaru SmartArt.
5. Nyní přidejte [**Child Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pro vybraný [**Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode) na pozici 2 a nastavte jeho text.
6. Uložte prezentaci.

```java
// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Přístup k uzlu SmartArt na indexu 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Přidání nového poduzlu na pozici 2 do nadřazeného uzlu
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Přidání textu
    chNode.getTextFrame().setText("Sample Text Added");

    // Uložení prezentace
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k uzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že nemůžete změnit LayoutType SmartArt, protože je jen pro čtení a nastavuje se pouze při přidání tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. Projděte všechny [**Nodes**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Přistupte k informacím a zobrazte údaje jako pozice uzlu SmartArt, úroveň a Text.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet všechny tvary na prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Procházet všechny uzly uvnitř SmartArt
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
Následující ukázkový kód pomůže přistupovat k poduzlům patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. Projděte všechny [**Nodes**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
6. Pro každý vybraný uzel [**Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode) projděte všechny [**Child Nodes**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) uvnitř daného uzlu.
7. Přistupte k informacím a zobrazte údaje jako pozice [**Child Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , úroveň a Text.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet všechny tvary na prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Procházet všechny uzly uvnitř SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Přístup k uzlu SmartArt na indexu i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Procházet poduzly v uzlu SmartArt na indexu i
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
V tomto příkladu se naučíte přistupovat k poduzlům na konkrétní pozici patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Přidejte tvar typu [**StackedList**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) SmartArt.
4. Přistupte k přidanému tvaru SmartArt.
5. Přistupte k uzlu na indexu 0 v přístupném tvaru SmartArt.
6. Nyní přistupte k [**Child Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) na pozici 1 pro přístupný uzel SmartArt pomocí metody **get_Item()**.
7. Přistupte k informacím a zobrazte údaje jako pozice [**Child Node**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , úroveň a Text.

```java
// Vytvoření instance prezentace
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidání tvaru SmartArt na první snímek
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
V tomto příkladu se naučíte odstranit uzly uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. Zkontrolujte, zda má [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) více než 0 uzlů.
6. Vyberte uzel SmartArt, který má být odstraněn.
7. Nyní odstraňte vybraný uzel pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
8. Uložte prezentaci.

```java
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projděte všechny tvary na prvním snímku
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
V tomto příkladu se naučíte odstranit uzly uvnitř tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. Vyberte uzel tvaru SmartArt na indexu 0.
6. Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
7. Nyní odstraňte uzel na **Position 1** pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
8. Uložte prezentaci.

```java
// Načtěte požadovanou prezentaci
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Projděte všechny tvary na prvním snímku
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
Nyní Aspose.Slides for Android via Java podporuje nastavení vlastností [SmartArtShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#setX-float-) a [Y](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#setY-float-). Kód níže ukazuje, jak nastavit vlastní pozici, velikost a rotaci SmartArtShape; také berte na vědomí, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů. S vlastními nastaveními pozice může uživatel nastavit uzly dle požadavků.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Přesunutí tvaru SmartArt na novou pozici
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Změna šířek tvaru SmartArt
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
{{% alert color="primary" %}} 

V tomto článku podrobně prozkoumáme funkce tvarů SmartArt přidaných do snímků prezentace programově pomocí Aspose.Slides for Android via Java.

{{% /alert %}} 

Pro naše zkoumání v různých částech tohoto článku použijeme následující zdrojový tvar SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Obrázek: Zdrojový tvar SmartArt na snímku**|

V následujícím ukázkovém kódu zkoumáme, jak identifikovat **Assistant Nodes** v kolekci uzlů SmartArt a měnit je.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na druhý snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Ověřte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) a přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt), pokud jde o SmartArt.
5. Projděte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou [**Assistant Nodes**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
6. Změňte stav asistenčního uzlu na běžný uzel.
7. Uložte prezentaci.

```java
// Vytvoření instance prezentace
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Procházet všechny tvary na prvním snímku
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
                    // Nastavení asistenčního uzlu na false a převod na běžný uzel
                    node.isAssistant();
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
|**Obrázek: Změněné asistenční uzly v tvaru SmartArt na snímku**|

## **Nastavení výplně uzlu**
Aspose.Slides for Android via Java umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplň. Tento článek popisuje, jak vytvořit a přistupovat k tvarům SmartArt a nastavit jejich výplň pomocí Aspose.Slides for Android via Java.

Postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArt) nastavením jeho [**LayoutType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Nastavte [**FillFormat**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getFillFormat--) pro uzly tvaru SmartArt.
5. Uložte upravenou prezentaci jako soubor PPTX.

```java
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

## **Generování miniatury poduzlu SmartArt**
Vývojáři mohou vygenerovat miniaturu poduzlu SmartArt podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. [Add SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Získejte referenci na uzel pomocí jeho indexu.
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu.

```java
// Vytvoření instance třídy Presentation, která reprezentuje soubor PPTX 
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

## **Často kladené otázky**

**Je animace SmartArt podporována?**

Ano. SmartArt je považován za běžný tvar, takže můžete [aplikovat standardní animace](/slides/cs/androidjava/shape-animation/) (vstup, odchod, zvýraznění, trajektorie) a upravit časování. V případě potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?**

Použijte a vyhledejte podle [alternativního textu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getAlternativeText--). Nastavením výrazného AltText na SmartArt jej můžete programově najít bez spoléhání se na interní identifikátory.

**Zůstane vzhled SmartArt zachován při konverzi prezentace do PDF?**

Ano. Aspose.Slides rendruje SmartArt s vysokou vizuální přesností během [exportu do PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy i efekty.

**Mohu extrahovat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete renderovat tvar SmartArt do [rasterových formátů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) nebo do [SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo webové použití.
---
title: Správa uzlů tvaru SmartArt v prezentacích pomocí JavaScriptu
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/nodejs-java/manage-smartart-shape-node/
keywords:
- Uzel SmartArt
- Poduzel
- Přidat uzel
- Pozice uzlu
- Přístup k uzlu
- Odstranit uzel
- Vlastní pozice
- Uzel asistenta
- Formát výplně
- Vykreslit uzel
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v PPT a PPTX pomocí Aspose.Slides pro Node.js. Získejte přehledné ukázky kódu JavaScript a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je organizována pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje programově pracovat s těmito uzly SmartArt: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvaru SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit uzel asistenta na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vygenerovat miniaturu obrázku pro poduzel SmartArt.

## **Přidání uzlu SmartArt do prezentace PowerPoint pomocí JavaScriptu**
Aspose.Slides pro Node.js prostřednictvím Java poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Níže uvedený ukázkový kód vám pomůže přidat uzel a poduzel do tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. [Přidejte nový uzel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) do tvaru SmartArt [**NodeCollection**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt#getAllNodes--) a nastavte text v TextFrame.
1. Nyní [přidejte](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) [**poduzel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) do nově přidaného uzlu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) a nastavte text v TextFrame.
1. Uložte prezentaci.

```javascript
// Načtěte požadovanou prezentaci
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Procházejte všechny tvary v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            // Přidání nového uzlu SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Přidání textu
            TemNode.getTextFrame().setText("Test");
            // Přidání nového poduzlu do nadřazeného uzlu. Bude přidán na konec kolekce
            var newNode = TemNode.getChildNodes().addNode();
            // Přidání textu
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Uložení prezentace
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání uzlu SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu jsme vysvětlili, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy Presentation.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Přidejte na přístupném snímku tvar [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Získejte první uzel v přidaném tvaru SmartArt.
1. Nyní přidejte [**poduzel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pro vybraný [**uzel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode) na pozici 2 a nastavte jeho text.
1. Uložte prezentaci.

```javascript
// Creating a presentation instance
var pres = new aspose.slides.Presentation();
try {
    // Access the presentation slide
    var slide = pres.getSlides().get_Item(0);
    // Add Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accessing the SmartArt node at index 0
    var node = smart.getAllNodes().get_Item(0);
    // Adding new child node at position 2 in parent node
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Add Text
    chNode.getTextFrame().setText("Sample Text Added");
    // Save Presentation
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k uzlu SmartArt v prezentaci PowerPoint pomocí JavaScriptu**
Níže uvedený ukázkový kód vám pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že nelze změnit LayoutType SmartArt, protože je jen pro čtení a je nastaven pouze při přidání tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. Procházejte všechny [**uzly**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
1. Přistupujte k informacím, jako je pozice uzlu SmartArt, úroveň a text.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Získejte první snímek
    var slide = pres.getSlides().get_Item(0);
    // Procházejte všechny tvary v prvním snímku
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            // Procházejte všechny uzly uvnitř SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Přístup k uzlu SmartArt na indexu i
                var node = smart.getAllNodes().get_Item(j);
                // Výpis parametrů uzlu SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k poduzlu SmartArt**
Níže uvedený ukázkový kód vám pomůže přistupovat k poduzlům patřícím příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. Procházejte všechny [**uzly**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt#getAllNodes--) uvnitř tvaru SmartArt.
1. Pro každý vybraný [**uzel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode) tvaru SmartArt procházejte všechny [**poduzly**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) uvnitř konkrétního uzlu.
1. Přistupujte k informacím, jako je pozice poduzlu, úroveň a text.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Získejte první snímek
    var slide = pres.getSlides().get_Item(0);
    // Procházejte všechny tvary v prvním snímku
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            // Procházejte všechny uzly uvnitř SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Přístup k uzlu SmartArt na indexu i
                var node0 = smart.getAllNodes().get_Item(i);
                // Procházení poduzlů v uzlu SmartArt na indexu i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Přístup k poduzlu v uzlu SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Výpis parametrů poduzlu SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíte přistupovat k poduzlům na určité pozici patřícím příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Přidejte na snímek tvar SmartArt typu [**StackedList**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Přistupte k přidanému tvaru SmartArt.
1. Přistupte k uzlu s indexem 0 v přístupném tvaru SmartArt.
1. Nyní přistupte k [**poduzlu**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) na pozici 1 pro vybraný uzel SmartArt pomocí metody **get_Item()**.
1. Přistupujte k informacím, jako je pozice poduzlu, úroveň a text.

```javascript
// Vytvořte instanci prezentace
var pres = new aspose.slides.Presentation();
try {
    // Přístup k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Přidání tvaru SmartArt do prvního snímku
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Přístup k uzlu SmartArt na indexu 0
    var node = smart.getAllNodes().get_Item(0);
    // Přístup k poduzlu na pozici 1 v rodičovském uzlu
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Výpis parametrů poduzlu SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění uzlu SmartArt v prezentaci PowerPoint pomocí JavaScriptu**
V tomto příkladu se naučíte odstranit uzly uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. Zkontrolujte, zda má SmartArt více než 0 uzlů.
1. Vyberte uzel SmartArt, který má být odstraněn.
1. Nyní odstraňte vybraný uzel pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Uložte prezentaci.

```javascript
// Načtěte požadovanou prezentaci
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Procházejte všechny tvary v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Přístup k uzlu SmartArt na indexu 0
                var node = smart.getAllNodes().get_Item(0);
                // Odstranění vybraného uzlu
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Uložení prezentace
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění uzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíte odstranit uzly uvnitř tvaru SmartArt na určité pozici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. Vyberte uzel tvaru SmartArt s indexem 0.
1. Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
1. Nyní odstraňte uzel na **pozici 1** pomocí metody [**RemoveNode**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Uložte prezentaci.

```javascript
// Načtěte požadovanou prezentaci
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Procházejte všechny tvary v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Přístup k uzlu SmartArt na indexu 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Odstranění poduzlu na pozici 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Uložení prezentace
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení vlastního umístění pro poduzel v SmartArt**
Nyní Aspose.Slides pro Node.js prostřednictvím Java podporuje nastavení vlastností [SmartArtShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setX-float-) a [Y](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setY-float-). Ukázkový úryvek níže ukazuje, jak nastavit vlastní pozici, velikost a rotaci SmartArtShape; také je třeba poznamenat, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů. S vlastními nastaveními pozice může uživatel nastavit uzly podle požadavků.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Přesuňte tvar SmartArt na novou pozici
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Změňte šířky tvaru SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Změňte výšku tvaru SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Změňte natočení tvaru SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kontrola uzlu asistenta**
{{% alert color="primary" %}} 

V tomto článku budeme dále zkoumat funkce tvarů SmartArt přidaných do snímků prezentace programově pomocí Aspose.Slides pro Node.js prostřednictvím Java.

{{% /alert %}} 

Budeme používat následující zdrojový tvar SmartArt pro naše vyšetřování v různých částech tohoto článku.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Obrázek: Zdrojový tvar SmartArt na snímku**|

V následujícím ukázkovém kódu budeme zjišťovat, jak identifikovat **uzly asistenta** v kolekci uzlů SmartArt a měnit je.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci se SmartArt tvarem.
1. Získejte referenci na druhý snímek pomocí jeho indexu.
1. Procházejte všechny tvary v prvním snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt), a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).
1. Procházejte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou [**uzly asistenta**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Změňte stav uzlu asistenta na běžný uzel.
1. Uložte prezentaci.

```javascript
// Vytvoření instance prezentace
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Procházejte každý tvar v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArt
            var smart = shape;
            // Procházení všech uzlů tvaru SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Zkontrolujte, zda je uzel asistentní
                if (node.isAssistant()) {
                    // Nastavení asistentního uzlu na false a převod na normální uzel
                    node.isAssistant();
                }
            }
        }
    }
    // Uložení prezentace
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Obrázek: Změněné uzly asistenta ve tvaru SmartArt na snímku**|

## **Nastavení výplňového formátu uzlu**
Aspose.Slides pro Node.js prostřednictvím Java umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňový formát. Tento článek popisuje, jak vytvořit a přistupovat k tvarům SmartArt a nastavit jejich výplňový formát pomocí Aspose.Slides pro Node.js prostřednictvím Java.

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) nastavením jeho [**LayoutType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Nastavte [**FillFormat**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getFillFormat--) pro uzly tvaru SmartArt.
1. Uložte upravenou prezentaci jako soubor PPTX.

```javascript
// Vytvořte instanci prezentace
var pres = new aspose.slides.Presentation();
try {
    // Přístup k snímku
    var slide = pres.getSlides().get_Item(0);
    // Přidání tvaru SmartArt a uzlů
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Nastavení barvy výplně uzlu
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Uložení prezentace
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generování miniatury poduzlu SmartArt**
Vývojáři mohou vygenerovat miniaturu poduzlu SmartArt podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. [Přidejte SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Získejte referenci na uzel pomocí jeho indexu.
1. Získejte miniaturu obrázku.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přidejte SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Získejte referenci na uzel pomocí jeho indexu
    var node = smart.getNodes().get_Item(1);
    // Získejte miniaturu
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Uložte miniaturu
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Je animace SmartArt podporována?**

Ano. SmartArt je považován za běžný tvar, takže můžete [použít standardní animace](/slides/cs/nodejs-java/shape-animation/) (vstup, odchod, důraz, trajektorie pohybu) a upravit časování. V případě potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?**

Přiřaďte a vyhledejte pomocí [alternativního textu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getalternativetext/). Nastavením výrazného AltTextu na SmartArt jej můžete najít bez použití interních identifikátorů.

**Zůstane vzhled SmartArt zachován při převodu prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální přesností během [exportu do PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), čímž zachovává rozvržení, barvy a efekty.

**Mohu získat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete vykreslit tvar SmartArt do [rastrých formátů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) nebo do [SVG](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo použití na webu.
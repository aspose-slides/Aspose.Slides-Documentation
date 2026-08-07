---
title: Spravovat značky a vlastní data v prezentacích na Androidu
linktitle: Značky a vlastní data
type: docs
weight: 300
url: /cs/androidjava/managing-tags-and-custom-data
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní XML část
- metadata XML
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se spravovat značky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro Android s využitím jazyka Java, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje se značkami a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako značky nebo vlastní XML části. Značky jsou jednoduché dvojice klíč‑hodnota typu string, zatímco vlastní XML části mohou uchovávat strukturovaná metadata a aplikačně specifické XML náklady.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, audit a odstranění vlastních XML částí na úrovních prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata shody, data vazby šablony nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje několik částí propojených vztahy. Například část snímku obsahuje obsah jediného snímku a může mít explicitní vztahy k dalším částem definovaným podle ISO/IEC 29500.

Vlastní data lze uložit jako značky ([ITagCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITagCollection)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Obě jsou k dispozici přes rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Značky ukládají jednoduché řetězcové dvojice klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přiřazeny k prezentaci, snímku nebo tvaru.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) vrací kolekci vlastních XML částí přiřazených konkrétnímu objektu prezentace. Například:

- `presentation.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části přiřazené samotné prezentaci.
- `slide.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části přiřazené konkrétnímu snímku.
- `shape.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části přiřazené konkrétnímu tvaru.

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) pokud potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) k přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce dat na úrovni prezentace:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add přiřazuje identifikátor automaticky. Nastavte konkrétní UUID pouze v případě potřeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` může také přijímat XML jako pole bajtů nebo vstupní proud, což je užitečné, když je XML obsah již dostupný v binární formě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data lze přiřadit konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo vazební informace.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Úroveň, na které je část přidána, určuje, ve které kolekci `getCustomData().getCustomXmlParts()` se nachází vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata celého dokumentu, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Výpis a audit všech vlastních XML částí**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) k získání všech vlastních XML částí z prezentace. Každý [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart/) vystavuje svůj identifikátor, XML obsah a přidružené schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Metoda [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) vrací XML schémata přidružená k vlastní XML části. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) a [`setXmlAsString()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) k práci s XML jako UTF‑8 řetězcem, nebo [`getXmlData()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) a [`setXmlData()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) k práci s čistými bajty XML.

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) vrací UUID, které identifikuje vlastní XML část v dokumentu Office Open XML. Použijte [`setItemId()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) když integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah i identifikátor:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Přečtěte aktuální XML jako text.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Aktualizujte XML jako řetězec UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData poskytuje stejný obsah XML jako surové bajty.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Nahraďte identifikátor, pokud to integrace vyžaduje.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při volání `setXmlAsString` nebo `setXmlData` poskytněte platné, ne‑prázdné XML. Použijte jednu nebo druhou reprezentaci podle toho, zda aplikace pracuje převážně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides nabízí několik způsobů, jak odstranit vlastní XML data:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#remove--) odstraňuje vlastní XML část z prezentace.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) odstraňuje část na zadaném indexu kolekce.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle reference:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud již máte objekt `ICustomXmlPart` a chcete odstranit tuto část přímo z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart.remove()`.

Můžete také odstranit položku podle indexu:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Vymazání všech vlastních XML částí ze sbírky**

Použijte `clear`, když mají být všechny vlastní XML části přiřazené konkrétnímu objektu prezentace odstraněny.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` ovlivňuje jen vybranou sbírku. Například vymazání sbírky snímku nevymaže sbírky na úrovni prezentace ani tvaru.

Pro odstranění každé vlastní XML části v prezentaci projděte `getAllCustomXmlParts()` a odstraňte každou část:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Zpracování propojených nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu. Například existující soubor může obsahovat vztahy z různých snímků nebo tvarů na stejnou podkladovou XML část.

Sdílenou část je třeba považovat za jeden datový objekt s více odkazy:

- Aktualizace pomocí `setXmlAsString`, `setXmlData` nebo `setItemId` změní podkladovou XML část, takže změna se projeví všude, kde je část referencována.
- `getItemId()` lze použít k identifikaci stejné XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `getCustomXmlParts()` ji odebere jen z této kolekce. Použijte `ICustomXmlPart.remove()` pokud má být část odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektů, abyste zjistili, zda ji stále odkazují jiné snímky nebo tvary.

Přetížení `add` vytváří novou vlastní XML část z XML obsahu; nepřijímá existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji setkány při načítání prezentací, které je již obsahují.

Následující příklad auditu kolekcí na úrovni prezentace, snímku a tvaru podle `ItemId` a výpisu částí odkazovaných z více než jednoho místa:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou participovat na více vztazích.

## **Získání hodnot značek**

V Slides odpovídá značka metodě `IDocumentProperties.getKeywords()`. Tento ukázkový kód ukazuje, jak získat hodnotu značky pomocí Aspose.Slides pro Android prostřednictvím Java pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Přidání značek do prezentací**

Aspose.Slides umožňuje přidávat značky do prezentací. Značka obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat značky za tímto účelem. Například pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit značku „North American“ a přiřadit jako její hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat značku do [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) pomocí Aspose.Slides pro Android prostřednictvím Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Značky lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Omezení**

Značky přidané přes kolekci `getCustomData().getTags()` jsou uloženy jen v souboru PowerPoint. **Nejsou** přenášeny do struktury značek PDF při exportu prezentace do PDF. Proto nelze získat vlastní identifikátor uložený jako značka z označeného PDF.

**Obrana**: Můžete uložit vlastní identifikátor do **alternativního textu** objektu (například `shape.setAlternativeText("MyId")`). Po exportu do PDF se alternativní text může objevit ve struktuře značek PDF.

## **Často kladené otázky**

**Mohu odstranit všechny značky z prezentace, snímku nebo tvaru najednou?**

Ano. Kolekce [tag collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#clear--) která smaže všechny páry klíč‑hodnota najednou.

**Jak mohu smazat jednu značku podle jejího názvu bez procházení celé kolekce?**

Použijte [remove(name)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [tag collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) a odstraňte značku podle jejího klíče.

**Jak mohu získat úplný seznam názvů značek pro analytiku nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) na [tag collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/); vrátí pole všech názvů značek.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) k získání všech vlastních XML částí v prezentaci.

**Mám použít `getXmlAsString`/`setXmlAsString` nebo `getXmlData`/`setXmlData` k aktualizaci vlastní XML části?**

Použijte `getXmlAsString` a `setXmlAsString`, když aplikace pracuje s textem XML v UTF‑8. Použijte `getXmlData` a `setXmlData`, když je XML již dostupné jako pole bajtů nebo je vhodnější binární zpracování. Obě reprezentace odkazují na stejný XML obsah vlastní XML části.
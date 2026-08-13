---
title: Správa tagů a vlastních dat v prezentacích na Androidu
linktitle: Tagy a vlastní data
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
description: "Naučte se, jak spravovat tagy a vlastní XML data v PowerPoint prezentacích pomocí Aspose.Slides pro Android v Javě, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze ukládat jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota ve formě řetězců, zatímco vlastní XML části mohou uchovávat strukturovaná metadata a aplikací specifické XML payloady.

Aspose.Slides poskytuje API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovních prezentace, snímku a objektu. Vlastní XML části jsou užitečné pro integrace, které ukládají informace, jako jsou identifikátory správy dokumentů, stav pracovního postupu, metadata souladu, data vazby na šablonu nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí spojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k dalším částem definované podle ISO/IEC 29500.

Vlastní data lze ukládat jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITagCollection)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Obě jsou dostupné prostřednictvím rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomData/).

{{% alert color="info" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být asociovány s prezentací, snímkem nebo objektem.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) vrací kolekci vlastních XML částí asociovaných s konkrétním objektem prezentace. Například:

- `presentation.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s samotnou prezentací.
- `slide.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `shape.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním objektem.

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) když potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou asociovány.

### **Přidání vlastní XML části do prezentace**

Použijte [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) , aby jste přidali XML data do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

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

    // add automaticky přiřadí identifikátor. Nastavte konkrétní UUID pouze v případě potřeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` může také přijímat XML jako pole bytů nebo vstupní stream, což je užitečné, když je obsah XML již k dispozici v binární podobě.

### **Přidání vlastní XML části do snímku nebo objektu**

Vlastní XML data mohou být asociována s konkrétním snímkem nebo objektem místo celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

Následující příklad přidává jednu vlastní XML část do snímku a další do objektu:

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

Úroveň, na které je část přidána, určuje, která kolekce objektu `getCustomData().getCustomXmlParts()` obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata vztahující se k celému dokumentu, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni objektu pro metadata spojená s jednotlivým objektem.

### **Vypsání a audit všech vlastních XML částí**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) , abyste získali všechny vlastní XML části z prezentace. Každý [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart/) poskytuje svůj identifikátor, XML obsah a související schémata jmenných prostorů.

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

`ICustomXmlPart.getNamespaceSchemas()` vrací XML schémata spojená s vlastní XML částí. Tato informace může být užitečná při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) a [`setXmlAsString()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) , abyste pracovali s XML jako řetězcem UTF‑8, nebo [`getXmlData()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) a [`setXmlData()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) , abyste pracovali s nepracovanými bajty XML.

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) vrací UUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Použijte [`setItemId()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) , když integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah a identifikátor:

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

    // Nahraďte identifikátor, pokud je to požadováno integrací.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při volání `setXmlAsString` nebo `setXmlData` poskytněte platné, ne‑prázdné XML. Použijte jednu reprezentaci nebo druhou v závislosti na tom, zda aplikace pracuje převážně s řetězci nebo s bajty.

### **Odstranění vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odstranit vlastní XML data:

- `ICustomXmlPart.remove` odstraňuje vlastní XML část z prezentace.
- `ICustomXmlPartCollection.remove` odstraňuje konkrétní část z kolekce vlastních XML částí.
- `ICustomXmlPartCollection.removeAt` odstraňuje část na zadaném indexu kolekce.
- `ICustomXmlPartCollection.clear` odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle odkazu:

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

Pokud již máte `ICustomXmlPart` a chcete odstranit tuto část z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart.remove()`.

Můžete také odstranit položku podle indexu:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Vymazání všech vlastních XML částí z kolekce**

Použijte `clear`, když je potřeba odstranit všechny vlastní XML části spojené s konkrétním objektem prezentace.

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

`clear` ovlivňuje pouze vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace nebo objektu.

Pro odstranění všech vlastních XML částí v prezentaci iterujte přes `getAllCustomXmlParts()` a odstraňte každou část:

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

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo objektů ke stejné podkladové vlastní XML části.

Sdílená část by měla být považována za jeden datový objekt s více odkazy:

- Aktualizace pomocí `setXmlAsString`, `setXmlData` nebo `setItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `getItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `getCustomXmlParts()` ji odstraní z této kolekce. Použijte `ICustomXmlPart.remove()`, pokud má být samotná část odstraněna z prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektů, abyste zjistili, zda na ni stále odkazují jiné snímky nebo objekty.

Přetížené verze `add` vytvoří novou vlastní XML část z XML obsahu; nepřijímají existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji setkávány při načítání prezentací, které je již obsahují.

Následující příklad provádí audit kolekcí na úrovni prezentace, snímku a objektu podle `ItemId` a hlásí části odkazované z více než jednoho místa:

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

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata část může být součástí více než jednoho vztahu.

## **Získání hodnot tagů**

V Slides tag odpovídá metodě `IDocumentProperties.getKeywords()`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro Android přes Java pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat tagy pro tento účel. Například, pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit tag pro Severní Ameriku a přiřadit mu jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat tag do [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) pomocí Aspose.Slides pro Android přes Java:

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

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide):

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

Tagy přidané prostřednictvím kolekce `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze získat vlastní identifikátor přiřazený jako tag z PDF s tagy.

**Obejití**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (například `shape.setAlternativeText("MyId")`). Po exportu do PDF se může Alt Text objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo objektu jedním operací?**

Ano. [Kolekce tagů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#clear--) , která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu bez iterace celou kolekcí?**

Použijte [remove(name)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [kolekci tagů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) , abyste smazali tag podle jeho klíče.

**Jak mohu získat kompletní seznam názvů tagů pro analytiku nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) na [kolekci tagů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) ; vrátí pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) , abyste získali všechny vlastní XML části v prezentaci.

**Mám použít `getXmlAsString`/`setXmlAsString` nebo `getXmlData`/`setXmlData` pro aktualizaci vlastní XML části?**

Použijte `getXmlAsString` a `setXmlAsString`, když aplikace pracuje s textem XML v kódování UTF‑8. Použijte `getXmlData` a `setXmlData`, když je XML již k dispozici jako pole bajtů nebo je výhodnější binární zpracování. Obě reprezentace odkazují na XML obsah téže vlastní XML části.
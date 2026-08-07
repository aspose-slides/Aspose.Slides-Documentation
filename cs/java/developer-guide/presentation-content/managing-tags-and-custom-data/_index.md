---
title: Správa štítků a vlastních dat v prezentacích pomocí Javy
linktitle: Štítky a vlastní data
type: docs
weight: 300
url: /cs/java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- štítek
- vlastní data
- vlastní XML
- vlastní XML část
- metadata XML
- ItemId
- přidat štítek
- hodnoty páru
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak spravovat štítky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro Javu, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje se štítky a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako štítky nebo vlastní XML části. Štítky jsou jednoduché páry klíč‑hodnota typu string, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikací specifické XML náklady.

Aspose.Slides poskytuje rozhraní pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku i tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata shody, data pro vazbu na šablonu nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentace**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí spojených pomocí vztahů. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k jiným částem definovaným v ISO/IEC 29500.

Vlastní data lze uložit jako štítky ([ITagCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITagCollection)) nebo vlastní XML části ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection)). Oba jsou dostupné přes rozhraní [`ICustomData`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Štítky ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přidruženy k prezentaci, snímku nebo tvaru.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomData#getCustomXmlParts--) vrací kolekci vlastních XML částí přidružených k danému objektu prezentace. Například:

- `presentation.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené přímo s prezentací.
- `slide.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `shape.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním tvarem.

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) pokud potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

K přidání XML dat do kolekce vlastní XML části použijte [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-). XML musí být platné a nesmí být prázdné.

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

    // add automaticky přiřazuje identifikátor. Nastavte konkrétní UUID pouze v případě potřeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` může také přijímat XML jako pole bajtů nebo vstupní stream, což je užitečné, když je XML obsah již k dispozici v binární formě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data lze přiřadit konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, pokud metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

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

Úroveň, na které je část přidána, určuje, do které kolekce `getCustomData().getCustomXmlParts()` patří vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata celého dokumentu, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Výpis a audit všech vlastních XML částí**

Pomocí [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) získáte všechny vlastní XML části v prezentaci. Každá [`ICustomXmlPart`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart/) expose své identifikátory, XML obsah a související schémata jmenných prostorů.

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) vrací XML schémata přidružená k vlastní XML části. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML generované externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

K práci s XML jako řetězcem UTF‑8 použijte [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) a [`setXmlAsString()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-). Pro práci s čistými bajty XML použijte [`getXmlData()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#getXmlData--) a [`setXmlData()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-).

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#getItemId--) vrací UUID identifikující vlastní XML část v dokumentu Office Open XML. Použijte [`setItemId()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) pokud integrace vyžaduje nový identifikátor.

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

    // getXmlData poskytuje stejný XML obsah jako surové bajty.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Nahraďte identifikátor, když to integrace vyžaduje.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při volání `setXmlAsString` nebo `setXmlData` poskytněte platné, ne‑prázdné XML. Použijte jeden nebo druhý způsob podle toho, zda aplikace pracuje převážně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides nabízí několik způsobů, jak odstranit vlastní XML data:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPart#remove--) odstraňuje vlastní XML část z prezentace.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) odstraňuje část na zadaném indexu v kolekci.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection#clear--) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace pomocí reference:

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

Pokud již máte instanci `ICustomXmlPart` a chcete tuto část odstranit z prezentace místo práce s konkrétní kolekcí, zavolejte `customXmlPart.remove()`.

Můžete také odstranit položku podle indexu:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Vyprázdnění všech vlastních XML částí v kolekci**

Použijte `clear`, když je potřeba odstranit všechny vlastní XML části přidružené k určitému objektu prezentace.

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

`clear` ovlivňuje pouze vybranou kolekci. Například vyprázdnění kolekce snímku nevyprázdní kolekci na úrovni prezentace ani na úrovni tvaru.

Pro odebrání každé vlastní XML části v celé prezentaci iterujte přes `getAllCustomXmlParts()` a odstraňte každou část:

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

### **Práce s propojenými nebo sdílenými vlastními XML částmi**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována více než jedním objektem prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo tvarů ke stejné podkladové vlastní XML části.

Sdílená část by měla být považována za jeden datový objekt s více odkazy:

- Aktualizace pomocí `setXmlAsString`, `setXmlData` nebo `setItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `getItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektu.
- Odstranění části z konkrétní kolekce `getCustomXmlParts()` ji odstraní jen z této kolekce. Použijte `ICustomXmlPart.remove()` pokud má být část odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části prozkoumejte kolekce na úrovni objektu, abyste zjistili, zda na ni stále odkazují jiné snímky nebo tvary.

Přetížení `add` vytváří novou vlastní XML část z XML obsahu; nepřijímají existující `ICustomXmlPart`. Proto jsou sdílené vztahy nejčastěji zaznamenány při načítání prezentací, které je již obsahují.

Následující příklad auditně prochází kolekce na úrovni prezentace, snímku a tvaru podle `ItemId` a hlásí části odkazované z více míst:

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

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou participovat ve více vztazích.

## **Získání hodnot štítků**

V Slides odpovídá štítek metodě `IDocumentProperties.getKeywords()`. Tento ukázkový kód ukazuje, jak získat hodnotu štítku pomocí Aspose.Slides for Java pro [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Přidání štítků do prezentací**

Aspose.Slides umožňuje přidávat štítky do prezentací. Štítek typicky sestává ze dvou položek:

- název vlastní vlastnosti, např. `MyTag`;
- hodnota vlastní vlastnosti, např. `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete pro tento účel přidat štítky. Například pokud chcete kategorizovat prezentace ze severoamerických zemí, můžete vytvořit štítek „North American“ a přiřadit mu jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat štítek do [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) pomocí Aspose.Slides for Java:

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

Štítky lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide):

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

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape):

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

Štítky přidané prostřednictvím kolekce `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** převedeny do struktury štítků PDF při exportu prezentace do PDF. Proto nelze získat vlastní identifikátor přiřazený jako štítek z označeného PDF.

**Obejití**: můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape.setAlternativeText("MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře štítků PDF.

## **Často kladené otázky**

**Mohu odebrat všechny štítky z prezentace, snímku nebo tvaru jedním krokem?**

Ano. [Kolekce štítků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#clear--) která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jediný štítek podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte [remove(name)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [kolekci štítků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/) pro smazání štítku podle jeho klíče.

**Jak mohu získat úplný seznam názvů štítků pro analytiku nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [kolekci štítků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/); vrací pole všech názvů štítků.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) pro získání všech vlastních XML částí v prezentaci.

**Mám použít `getXmlAsString`/`setXmlAsString` či `getXmlData`/`setXmlData` pro aktualizaci vlastní XML části?**

Použijte `getXmlAsString` a `setXmlAsString`, když aplikace pracuje s UTF‑8 XML textem. Použijte `getXmlData` a `setXmlData`, když je XML již k dispozici jako pole bajtů nebo je zpracování binárních dat výhodnější. Oba způsoby se vztahují k XML obsahu téže vlastní XML části.
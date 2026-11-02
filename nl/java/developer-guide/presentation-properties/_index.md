---
title: Beheer presentatieweigenschappen in Java
linktitle: Presentatieweigenschappen
type: docs
weight: 70
url: /nl/java/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatieweigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer presentatieweigenschappen in Aspose.Slides voor Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides for Java ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides laat u werken met presentatiedocumenteigenschappen via de [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). De onderstaande voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de toepassings- en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de output heeft gecreëerd.
{{% /alert %}}

## **Beheer presentatieweigenschappen**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatiewaarde. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde-paren op.

Aspose.Slides for Java biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde eigenschappen** om de documentmetadata te bekijken. Het dialoogvenster groepeert informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatie-inhoud als de documenteigenschappen. Wanneer een presentatie wordt versleuteld na het aanroepen van [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) met `false`, blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) aanroepen met `true` en de openbare metadata lezen zonder het openingswachtwoord op te geven.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen in de encryptie waren opgenomen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het controleert de laadmodus via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) en leest vervolgens ingebouwde eigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In deze modus wordt de dia-inhoud niet geladen. Dia's, masters, lay-outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kan auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoekopdrachten of document‑beheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen na het aanroepen van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) met `true` bedoeld voor het lezen van openbare metadata. Aspose.Slides kan gewijzigde eigenschappen van dat uitsluitend‑metadata‑object niet opslaan omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Het bijwerken daarvan vereist daarom het juiste openingswachtwoord en een volledige lading.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) gebruikt om te bevestigen dat encryptie behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te verifiëren:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Als een applicatie niet is toegestaan om de presentatie-inhoud te ontsleutelen of te laden, moet deze openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

De [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interface maakt ingebouwde metadata toegankelijk via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) en [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. De waarden hangen af van de invoerpresentatie; sommige velden kunnen leeg zijn.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) en [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). De opgeslagen PPTX bevat de nieuwe metadata.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Beheer de hyperlinkbasis**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) geeft de document‑niveau basis terug voor relatieve hyperlinks. Gebruik [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) om deze te wijzigen of te wissen. Dit is nuttig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het staat los van de individuele hyperlink van [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--): het wijzigen van de basis herschrijft de opgeslagen linkadressen niet en verandert geen absolute bestemmingen.

Het voorbeeld vereist een presentatie met zowel een relatieve link, zoals `target.html`, als een absolute link, zoals `https://example.org/absolute.html`. Het leest de bestaande basis, kent een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wordt de basis gewist met een lege tekenreeks en wordt de lege waarde geverifieerd in een apart opgeslagen bestand. Vervang het voorbeeldbasisadres door de locatie van uw gekoppelde bestanden.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

De twee verificatie‑berichten moeten `true` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen onaangeroerd.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de `old`‑map wees. Na het wijzigen van de basis naar de `new`‑map, opslaan en de presentatie opnieuw openen, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatieweigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op waarvoor geen bijbehorend ingebouwd veld bestaat. De [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) methode stelt u in staat een waarde toe te wijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een gehele versie‑waarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Het toekennen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Toegang tot en wijziging van aangepaste eigenschappen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) om erover te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) accepteert een nul‑gebaseerde index en retourneert de naam die wordt gebruikt door [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Het voorbeeld drukt elke originele naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live‑voorbeeld**

Probeer de [**Bekijk & bewerk PowerPoint-metadata**](https://products.aspose.app/slides/metadata) online‑app om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![Bekijk & bewerk PowerPoint-metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of ze leeg maken als de specifieke eigenschap dat toelaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig de eigenschap eerst te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatieweigenschappen benaderen zonder de presentatie volledig te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instantie te maken. Zie [**Maak een lichtgewicht presentatielijst**](/slides/nl/java/examine-presentation/) voor een volledig voorbeeld van rapportage en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet zijn versleuteld nadat [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) is aangeroepen met `false`, en moet worden geladen nadat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) is aangeroepen met `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑documenteigenschappen‑modus?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het juiste openingswachtwoord.
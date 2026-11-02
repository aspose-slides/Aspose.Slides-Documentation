---
title: Beheer presentatie‑eigenschappen op Android
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/androidjava/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- standaard‑eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides for Android via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides for Android via Java ondersteunt **standaard** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides biedt toegang tot presentatiedocumenteigenschappen via de [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/)‑interface. Een instantie van deze interface wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). De volgende voorbeelden tonen hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de applicatie‑ en producentmetadata bij het opslaan van presentaties; deze velden geven aan welke software de uitvoer heeft gemaakt.
{{% /alert %}}

## **Presentatie‑eigenschappen beheren**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatiewaarde. Ze vallen in twee categorieën:

- **Standaardeigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde‑paren op.

Aspose.Slides for Android via Java biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde eigenschappen** om de documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de presentatiewaarde als de documenteigenschappen. Wanneer een presentatie versleuteld wordt nadat [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) is aangeroepen met `false`, blijven de documenteigenschappen openbaar. Een applicatie kan dan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) aanroepen met `true` en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen wel in de versleuteling zijn opgenomen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het controleert de laadmodus via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) en leest vervolgens standaardeigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, lay‑outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) controleren voordat zij een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kunnen auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexeer‑, classificatie‑, zoek‑ of documentbeheer‑systemen een specifieke noodzaak hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die na het aanroepen van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) met `true` wordt geladen, bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat metadata‑enkel‑object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Het bijwerken hiervan vereist daarom het juiste openings‑wachtwoord en een volledige lading.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openings‑wachtwoord. Het opent de volledige presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), werkt openbare standaardeigenschappen bij en slaat het resultaat op. Vervolgens gebruikt het [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) om te verifiëren dat de versleuteling behouden blijft en opent het de openbare metadata opnieuw zonder wachtwoord om de nieuwe waarden te controleren:

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

Als een applicatie niet bevoegd is om de presentatie te ontsleutelen of de inhoud te laden, moet zij openbare eigenschappen van een versleuteld PPTX‑bestand beschouwen als alleen‑lezen.

## **Standaardeigenschappen benaderen**

De [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/)‑interface maakt standaardmetadata beschikbaar via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) en [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. Waarden hangen af van de invoerpresentatie; sommige velden kunnen leeg zijn.

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

## **Standaardeigenschappen wijzigen**

Om standaardmetadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), en [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). De opgeslagen PPTX bevat de nieuwe metadata.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De hyperlink‑basis beheren**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) retourneert de document‑brede basis voor relatieve hyperlinks. Gebruik [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) om deze te wijzigen of te wissen. Dit is handig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het staat los van de individuele hyperlink‑eigenschap [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--): het wijzigen van de basis herschrijft niet de opgeslagen koppelingen of verandert absolute bestemmingen.

Het voorbeeld vereist een presentatie met zowel een relatieve link, zoals `target.html`, als een absolute link, zoals `https://example.org/absolute.html`. Het leest de bestaande basis, wijst een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wist het de basis met een lege tekenreeks en verifieert de lege waarde in een apart opgeslagen bestand. Vervang het voorbeeldbasisadres door de locatie van uw gekoppelde bestanden.

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

De twee verificatie‑berichten moeten `true` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen intact.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis verwees naar de map `old`. Na het wijzigen van de basis naar de map `new`, opslaan en de presentatie opnieuw openen, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op waarvoor geen standaardveld bestaat. De [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-)‑methode laat u een waarde toewijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een gehele versie‑waarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

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

## **Aangepaste eigenschappen benaderen en wijzigen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) om erover te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) accepteert een index vanaf nul en retourneert de naam die door [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) is gebruikt. Het voorbeeld drukt elke oorspronkelijke naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, maakt de lus geen wijzigingen.

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

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een standaardeigenschap uit een presentatie verwijderen?**

Standaardeigenschappen maken integraal deel uit van de presentatie en kunnen niet volledig worden verwijderd. U kunt echter wel hun waarden wijzigen of, indien de eigenschap dit toestaat, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/androidjava/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De presentatie moet versleuteld zijn nadat [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) is aangeroepen met `false`, en moet worden geladen na het aanroepen van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) met `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus ‘alleen document‑eigenschappen laden’?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openings‑wachtwoord.
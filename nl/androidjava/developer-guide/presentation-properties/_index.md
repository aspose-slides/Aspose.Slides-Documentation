---
title: Beheer presentatie-eigenschappen op Android
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/androidjava/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document-metadata
- metadata bewerken
- controle-taal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor Android via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides voor Android via Java ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, de titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt u in staat om met documenteigenschappen van presentaties te werken via de [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de applicatie‑ en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de uitvoer heeft gemaakt.
{{% /alert %}}

## **Presentatie‑eigenschappen beheren**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatie‑inhoud. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde‑paren op.

Aspose.Slides voor Android via Java biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde eigenschappen** om documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld nadat [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) is aangeroepen met `false`, blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) aanroepen met `true` en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen in de versleuteling waren opgenomen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het controleert de laadsmodus via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) en leest vervolgens ingebouwde eigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

In deze modus wordt de dia‑inhoud niet geladen. Dia’s, masters, lay‑outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kan namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexerings-, classificatie-, zoek‑ of document‑beheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen na het aanroepen van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) met `true` bedoeld om openbare metadata te lezen. Aspose.Slides kan geen gewijzigde eigenschappen opslaan vanuit dat alleen‑metadata‑object, omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens binnen de versleutelde presentatie. Het bijwerken daarvan vereist daarom het juiste openings‑wachtwoord en een volledige load.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openings‑wachtwoord. Het opent de volledige presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) gebruikt om te verifiëren dat de versleuteling behouden blijft en wordt de openbare metadata zonder wachtwoord opnieuw geopend om de nieuwe waarden te controleren:

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

Als een applicatie niet mag ontsleutelen of de presentatie‑inhoud laden, moet hij de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

De [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) interface biedt ingebouwde metadata via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) en [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. De waarden hangen af van de invoer‑presentatie; sommige velden kunnen leeg zijn.

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

### **Revisienummer en bewerkingstijd rapporteren**

Om één rij te rapporteren voor elk PPTX‑bestand in een map die uw Android‑app kan lezen, roept u [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aan om de [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) te lezen zonder de dia’s te laden voor bewerking. De Android‑via‑Java‑API geeft de bewerkingstijd terug in milliseconden. Vervang het voorbeeld‑mappad door het pad naar uw bestanden. Het voorbeeld formatteert de duur als uren, minuten en seconden, met een dag‑telling voor duur van 24 uur of meer.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

Voor een presentatie met een geregistreerde bewerkingstijd van 1 dag, 2 uur en 5 minuten, toont het rapport de volgende uitvoer.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) leest een waarde die applicaties kunnen wijzigen met [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-). Het revisienummer alleen kan niet bepalen hoe vaak de presentatie is opgeslagen of de versiegeschiedenis reconstrueren.

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) leest de bewerkingstijd die in het bestand is geregistreerd. Een waarde van `00:00:00` betekent dat de opgeslagen duur nul is, zelfs als iemand de presentatie bewerkte.

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) en [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Het opgeslagen PPTX‑bestand bevat de nieuwe metadata.

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

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) retourneert de document‑niveau basis voor relatieve hyperlinks. Gebruik [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) om deze te wijzigen of leeg te maken. Dit is handig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het staat los van de [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) van een individuele hyperlink: het wijzigen van de basis herschrijft niet de opgeslagen linkadressen of wijzigt absolute bestemmingen.

Het voorbeeld vereist een presentatie die zowel een relatieve link bevat, zoals `target.html`, als een absolute link, zoals `https://example.org/absolute.html`. Het leest de bestaande basis, kent een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens maakt het de basis leeg met een lege string en verifieert de lege waarde in een apart opgeslagen bestand. Vervang het voorbeeld‑basisadres door de locatie van uw gekoppelde bestanden.

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

De twee verificatie‑berichten zouden `true` moeten afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen intact.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de map `old` verwees. Na het wijzigen van de basis naar de map `new`, het opslaan en opnieuw openen van de presentatie, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatieseigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op die geen overeenkomend ingebouwd veld hebben. De [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) methode stelt u in staat een waarde toe te wijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie aan, voegt twee tekstwaarden en een geheel‑getal‑versiewaarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

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

Dit voorbeeld opent een presentatie die aangepaste eigenschappen bevat en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) om er over te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) accepteert een nul‑gebaseerde index en retourneert de naam die door [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) wordt gebruikt. Het voorbeeld drukt elke originele naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

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

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal deel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter wel hun waarden wijzigen of ze leeg maken indien de specifieke eigenschap dat toestaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, aangezien Aspose.Slides de eigenschapswaarde automatisch bijwerkt.

**Kan ik presentatieseigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instantie te maken. Zie [Bouw een lichte presentatietinventaris](/slides/nl/androidjava/examine-presentation/) voor een volledig rapportagevoorbeeld en formaatspecifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De presentatie moet zijn versleuteld nadat [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) is aangeroepen met `false`, en moet worden geladen nadat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) is aangeroepen met `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑documenteigenschappen‑modus?**

Nee. Openbare en versleutelde eigenschaps‑data moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het laden van de volledige presentatie met het juiste openings‑wachtwoord.
---
title: Presentaties beveiligen met wachtwoorden in Java
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/java/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beveiligen
- presentatie beveiligen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbeperking
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- bescherming verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- bescherming uitschakelen
- schrijfbeperking verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u moeiteloos PowerPoint en OpenDocument presentaties met een wachtwoord kunt vergrendelen en ontgrendelen met Aspose.Slides voor Java. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om deze beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Normaal kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

Als je wilt dat alleen bepaalde gebruikers je presentatie aanpassen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen elementen in je presentatie wijzigen, aanpassen of kopiëren tenzij ze het wachtwoord invoeren. 

Echter, zelfs zonder het wachtwoord kan een gebruiker je document nog steeds openen en bekijken. In deze alleen‑lezen modus kan de gebruiker de inhoud – inclusief hyperlinks, animaties, effecten en andere elementen – in je presentatie bekijken, maar ze kunnen geen items kopiëren of de presentatie opslaan.

- **Openen**

Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie zelfs kunnen bekijken tenzij ze het wachtwoord invoeren.

Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties wijzigen – als mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen of eraan veranderingen aanbrengen.

**Opmerking:** Wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, wordt het presentatied bestand versleuteld.

## **Wachtwoordbeveiliging in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT – Microsoft PowerPoint-presentatie 
- ODP – OpenDocument-presentatie 
- OTP – OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbeperking instellen op een presentatie

**Andere bewerkingen**

Aspose.Slides laat je andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uitvoeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Een schrijfbeperking van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord beveiligd is.

## **Een presentatie beveiligen met een wachtwoord**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Vervolgens moet een gebruiker het wachtwoord invoeren om de vergrendelde presentatie te wijzigen. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [IProtectionManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan. 

Deze voorbeeldcode toont hoe je een presentatie kunt versleutelen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Een schrijfbeperking instellen op een presentatie**

Je kunt een markering toevoegen met de tekst “Niet wijzigen” aan een presentatie. Op deze manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbeperking versleutelt de presentatie niet. Daarom kunnen gebruikers—als ze dat willen—de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam maken. 

Om een schrijfbeperking in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) methode gebruiken. Deze voorbeeldcode toont hoe je een schrijfbeperking op een presentatie instelt:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Een versleutelde presentatie laden**

Aspose.Slides stelt je in staat een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#removeEncryption--) methode zonder parameters aanroepen. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden. 

Deze voorbeeldcode toont hoe je een presentatie kunt ontsleutelen: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // werken met ontsleutelde presentatie
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#removeEncryption--) methode aanroepen. Deze voorbeeldcode laat zien hoe je versleuteling van een presentatie verwijdert:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Schrijfbeperking van een presentatie verwijderen**

Je kunt Aspose.Slides gebruiken om de schrijfbeperking van een presentatiedbestand te verwijderen. Op deze manier kunnen gebruikers naar eigen inzicht wijzigen – en krijgen ze geen waarschuwingen bij het uitvoeren van dergelijke acties.

Je kunt de schrijfbeperking van een presentatie verwijderen met de [removeWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) methode. Deze voorbeeldcode toont hoe je de schrijfbeperking van een presentatie verwijdert:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Normaal hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie met een wachtwoord kunt beveiligen en tegelijkertijd gebruikers de mogelijkheid biedt om de eigenschappen te benaderen.

**Opmerking:** Standaard worden, wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je de documenteigenschappen zelfs na versleuteling toegankelijk wilt maken, biedt Aspose.Slides je precies die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te benaderen, geef dan `false` door aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Deze voorbeeldcode toont hoe je een presentatie kunt versleutelen terwijl je gebruikers toch toegang geeft tot de documenteigenschappen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) object aan en geef je `true` door aan [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In deze modus negeert Aspose.Slides het wachtwoord en laadt het alleen de publiek toegankelijke documenteigenschappen.

Het volgende code‑voorbeeld leest ingebouwde en aangepaste documenteigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Lees ingebouwde documenteigenschappen.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Lees aangepaste documenteigenschappen.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Deze werkwijze werkt alleen wanneer de documenteigenschappen onversleuteld (publiek) zijn gelaten toen de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, leidt het doorgeven van `true` aan `loadOptions.setOnlyLoadDocumentProperties` tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie, inclusief dia's en andere inhoud, te laden, moet je het juiste wachtwoord opgeven via [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Controleren of een presentatie met een wachtwoord beveiligd is**

Voordat je een presentatie laadt, wil je mogelijk controleren en bevestigen dat de presentatie niet met een wachtwoord beveiligd is. Op deze manier kun je fouten en soortgelijke problemen vermijden die ontstaan wanneer een met een wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze Java‑code toont hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord beveiligd is (zonder de presentatie zelf te laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides stelt je in staat te controleren of een presentatie versleuteld is. Hiervoor kun je de [isEncrypted](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#isEncrypted--) eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is en `false` als de presentatie niet versleuteld is. 

Deze voorbeeldcode toont hoe je kunt controleren of een presentatie versleuteld is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Controleren of een presentatie schrijfbeperkt is**

Aspose.Slides stelt je in staat te controleren of een presentatie schrijfbeperkt is. Hiervoor kun je de [isWriteProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IProtectionManager#isWriteProtected--) eigenschap gebruiken, die `true` retourneert als de presentatie schrijfbeperkt is en `false` als dat niet het geval is. 

Deze voorbeeldcode toont hoe je kunt controleren of een presentatie schrijfbeperkt is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt**

Je wilt wellicht controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode toont hoe je een wachtwoord kunt valideren:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // controleer of "pass" overeenkomt met
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert hij `false`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder op AES gebaseerde algoritmen, waarmee een hoog niveau van gegevensbeveiliging voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen een presentatie te openen?**

Er wordt een uitzondering gegooid als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met een wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte overhead met zich meebrengen tijdens het openen en opslaan. In de meeste gevallen is deze prestatie‑impact minimaal en heeft ze geen significante invloed op de algehele verwerkingstijd van je presentatietaken.
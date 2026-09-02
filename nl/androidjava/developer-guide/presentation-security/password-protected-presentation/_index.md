---
title: Beveilig presentaties met wachtwoorden op Android
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/androidjava/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beschermen
- presentatie beschermen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbescherming
- PowerPoint beveiliging
- presentatie beveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbescherming verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Vergrendel en ontgrendel moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer u een presentatie met een wachtwoord beveiligt, betekent dit dat u een wachtwoord instelt dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Typisch kunt u een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als u alleen bepaalde gebruikers uw presentatie wilt laten wijzigen, kunt u een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen de presentatie wijzigen, aanpassen of kopiëren (tenzij ze het wachtwoord invoeren). 

  Echter, in dit geval kan een gebruiker, zelfs zonder het wachtwoord, uw document toch openen. In deze alleen‑lezen‑modus kan de gebruiker de inhoud – hyperlinks, animaties, effecten en andere zaken – bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als u alleen bepaalde gebruikers uw presentatie wilt laten openen, kunt u een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van uw presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers uw presentaties wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen. 
  
  **Opmerking** dat wanneer u een presentatie beveiligt met een wachtwoord om openen te voorkomen, het presentatied bestand wordt versleuteld.

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in deze formaten: 

- PPTX en PPT - Microsoft PowerPoint‑presentatie 
- ODP - OpenDocument‑presentatie 
- OTP - OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt u in staat wachtwoordbeveiliging op presentaties toe te passen om wijziging te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides maakt het mogelijk andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord beschermd is.

## **Een presentatie versleutelen**

U kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord opgeven. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet u de encrypt‑methode (van [IProtectionManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager)) gebruiken om een wachtwoord voor de presentatie in te stellen. U geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe u een presentatie kunt versleutelen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Schrijfbescherming instellen voor een presentatie**

U kunt een markering “Niet wijzigen” aan een presentatie toevoegen. Zo kunt u gebruikers laten weten dat u niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbescherming de presentatie niet versleutelt. Daarom kunnen gebruikers – als ze willen – de presentatie wijzigen, maar om de wijzigingen op te slaan, moeten ze de presentatie met een andere naam opslaan. 

Om een schrijfbescherming in te stellen, moet u de [setWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) methode gebruiken. Deze voorbeeldcode laat zien hoe u een schrijfbescherming op een presentatie toepast:

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

Aspose.Slides maakt het mogelijk een versleuteld bestand te laden door het wachtwoord mee te geven. Om een presentatie te ontsleutelen, moet u de [removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) methode zonder parameters aanroepen. Vervolgens moet u het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe u een presentatie ontsleutelt: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // werk met ontsleutelde presentatie
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

U kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie openen of wijzigen zonder beperkingen. 

Om de versleuteling of wachtwoordbeveiliging te verwijderen, moet u de [removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) methode aanroepen. Deze voorbeeldcode laat zien hoe u de versleuteling van een presentatie verwijdert:

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

## **Schrijfbescherming van een presentatie verwijderen**

U kunt Aspose.Slides gebruiken om de schrijfbescherming van een presentatiedocument te verwijderen. Op deze manier kunnen gebruikers naar hartenlust wijzigen – en krijgen ze geen waarschuwingen bij het uitvoeren van dergelijke taken.

U kunt de schrijfbescherming van een presentatie verwijderen met de [removeWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) methode. Deze voorbeeldcode laat zien hoe u de schrijfbescherming van een presentatie verwijdert:

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

Typisch hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee u een presentatie kunt beveiligen met een wachtwoord en tegelijkertijd gebruikers in staat stelt de eigenschappen te benaderen.

**Opmerking:** Standaard, wanneer Aspose.Slides een presentatie versleutelt, worden de documenteigenschappen van de presentatie eveneens met een wachtwoord beveiligd. Als u de documenteigenschappen toegankelijk wilt houden, zelfs na versleuteling, maakt Aspose.Slides dit mogelijk.

Als u wilt dat gebruikers de eigenschappen van een versleutelde presentatie kunnen benaderen, geeft u `false` door aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Deze voorbeeldcode laat zien hoe u een presentatie versleutelt en tegelijk gebruikers toegang tot de documenteigenschappen biedt:

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

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maakt u een [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) object en geeft u `true` door aan [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke documenteigenschappen.

De volgende code‑voorbeeld leest ingebouwde en aangepaste documenteigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Deze workflow werkt alleen wanneer de documenteigenschappen onbeveiligd (publiek) zijn gelaten op het moment dat de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, veroorzaakt het doorgeven van `true` aan `loadOptions.setOnlyLoadDocumentProperties` een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie, inclusief dia’s en andere inhoud, te laden, moet u het juiste wachtwoord opgeven via [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Controleren of een presentatie met een wachtwoord beschermd is**

Voordat u een presentatie laadt, wilt u wellicht controleren of de presentatie niet met een wachtwoord beveiligd is. Zo voorkomt u fouten en soortgelijke problemen die ontstaan wanneer een met een wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze Java‑code laat zien hoe u een presentatie kunt onderzoeken om te zien of deze met een wachtwoord beschermd is (zonder de presentatie zelf te laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie versleuteld is. Gebruik hiervoor de [isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) eigenschap, die `true` teruggeeft als de presentatie versleuteld is of `false` als deze niet versleuteld is.

Deze voorbeeldcode laat zien hoe u kunt controleren of een presentatie versleuteld is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie schrijfbeschermd is. Gebruik hiervoor de [isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) eigenschap, die `true` teruggeeft als de presentatie schrijfbeschermd is of `false` als dit niet het geval is.

Deze voorbeeldcode laat zien hoe u kunt controleren of een presentatie schrijfbeschermd is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt**

U wilt wellicht bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe u een wachtwoord kunt valideren:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // controleer of "pass" overeenkomt met
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het resultaat is `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders is het resultaat `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke encryptiemethoden worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, waaronder AES‑gebaseerde algoritmen, wat een hoog niveau van databeveiliging voor uw presentaties garandeert.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het openen van een presentatie?**

Er wordt een uitzondering gegooid wanneer een onjuist wachtwoord wordt gebruikt, waardoor u wordt geïnformeerd dat de toegang tot de presentatie wordt geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met een wachtwoord beveiligde presentaties?**

Het versleutel‑ en ontsleutelproces kan een lichte overhead met zich meebrengen tijdens het openen en opslaan. In de meeste gevallen is deze prestatie‑impact minimaal en heeft het geen significante invloed op de totale verwerkingstijd van uw presentatietaken.
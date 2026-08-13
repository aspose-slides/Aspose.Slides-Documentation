---
title: Presentaties beveiligen met wachtwoorden op Android
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/androidjava/password-protected-presentation/
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
- schrijfbeveiliging
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeveiliging verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Vergrendel en ontgrendel moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Android via Java. Beveilig uw presentaties."
---
## **Introductie**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

In de praktijk kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Aanpassing**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen aanpassen, kun je een bewerkingsbeperking instellen. Deze beperking voorkomt dat mensen jouw presentatie aanpassen, wijzigen of kopiëren (tenzij ze het wachtwoord invoeren). 

  Echter, in dit geval kan een gebruiker, zelfs zonder het wachtwoord, het document openen en bekijken. In deze alleen‑lezen modus kan de gebruiker de inhoud of elementen—hyperlinks, animaties, effecten en andere—in je presentatie bekijken, maar hij/zij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van je presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties kunnen wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigen. 
  
  **Opmerking** dat wanneer je een presentatie met wachtwoord beveiligt om openen te voorkomen, het presentiebestand versleuteld wordt.

## **Wachtwoordbeveiliging voor Presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT - Microsoft PowerPoint‑presentatie 
- ODP - OpenDocument‑presentatie 
- OTP - OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides maakt het mogelijk om wachtwoordbeveiliging op presentaties toe te passen om modificaties te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbeveiliging instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides laat je andere taken uitvoeren die verband houden met wachtwoordbeveiliging en versleuteling op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeveiliging van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met wachtwoord beveiligd is.

## **Een Presentatie Versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [IProtectionManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Schrijfbeveiliging Instellen voor een Presentatie**

Je kunt een markering toevoegen met de tekst “Niet wijzigen” aan een presentatie. Op deze manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbeveiliging de presentatie niet versleutelt. Daarom kunnen gebruikers—als ze dat willen—de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam aanmaken. 

Om een schrijfbeveiliging in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbeveiliging voor een presentatie instelt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Een Versleutelde Presentatie Laden**

Aspose.Slides maakt het mogelijk om een versleutelde presentatie te laden door het juiste wachtwoord door te geven via [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/).

Deze voorbeeldcode laat zien hoe je een versleutelde presentatie opent: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // werken met ontsleutelde presentatie
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Versleuteling Verwijderen uit een Presentatie**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie openen of wijzigen zonder beperkingen.

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling uit een presentatie verwijdert:

```java
import com.aspose.slides.*;

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

## **Schrijfbeveiliging Verwijderen uit een Presentatie**

Je kunt Aspose.Slides gebruiken om de schrijfbeveiliging van een presentiebestand te verwijderen. Op deze manier kunnen gebruikers naar wens wijzigen—en krijgen ze geen waarschuwingen bij het uitvoeren van dergelijke handelingen.

Je kunt de schrijfbeveiliging van een presentatie verwijderen door de [removeWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) methode te gebruiken. Deze voorbeeldcode laat zien hoe je de schrijfbeveiliging van een presentatie verwijdert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eigenschappen van een Versleutelde Presentatie Ophalen**

In de praktijk hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie met een wachtwoord kunt beveiligen en toch gebruikers de mogelijkheid geeft de eigenschappen te raadplegen.

**Opmerking:** Standaard, wanneer Aspose.Slides een presentatie versleutelt, worden de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je de documenteigenschappen toegankelijk wilt maken, zelfs na versleuteling, biedt Aspose.Slides je precies die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te bekijken, geef dan `false` door aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Deze voorbeeldcode laat zien hoe je een presentatie versleutelt en toch gebruikers toegang geeft tot de documenteigenschappen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Alleen Documenteigenschappen Laden uit een Versleutelde Presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) object aan en geef je `true` door aan [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In deze modus negeert Aspose.Slides het wachtwoord en laadt het alleen de openbaar toegankelijke documenteigenschappen.

De volgende codevoorbeeld leest ingebouwde en aangepaste documenteigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Ingebouwde documenteigenschappen lezen.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Aangepaste documenteigenschappen lezen.
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

Deze werkwijze werkt alleen wanneer de documenteigenschappen onversleuteld (publiek) zijn gelaten bij het versleutelen van de presentatie. Als de documenteigenschappen versleuteld zijn, leidt het doorgeven van `true` aan `loadOptions.setOnlyLoadDocumentProperties` tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie te laden, inclusief dia's en andere inhoud, moet je het juiste wachtwoord doorgeven via [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Controleren of een Presentatie met Wachtwoord Beveiligd is**

Voordat je een presentatie laadt, wil je mogelijk controleren en bevestigen dat de presentatie niet met een wachtwoord is beveiligd. Op deze manier kun je fouten en soortgelijke problemen vermijden die ontstaan wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze Java‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord beveiligd is (zonder de presentatie zelf te laden):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een Presentatie Versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Om deze taak uit te voeren, kun je de [isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Controleren of een Presentatie Schrijfbeveiligd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeveiligd is. Om deze taak uit te voeren, kun je de [isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) eigenschap gebruiken, die `true` retourneert als de presentatie schrijfbeveiligd is of `false` als dat niet het geval is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeveiligd is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valideren of Bevestigen dat een Specifiek Wachtwoord is Gebruikt**

Je wilt misschien controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // controleren of "pass" overeenkomt met
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het retourneert `true` als de presentatie schrijfbeveiligd is met het opgegeven wachtwoord. Anders retourneert het `false`. 

{{% alert color="info" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke encryptiemethoden worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, waaronder op AES gebaseerde algoritmen, die een hoog niveau van gegevensbeveiliging voor je presentaties garanderen.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen een presentatie te openen?**

Er wordt een uitzondering gegenereerd als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte extra belasting veroorzaken tijdens open‑ en opslaan‑bewerkingen. In de meeste gevallen is deze prestatie‑impact minimaal en beïnvloedt ze de algehele verwerkingstijd van je presentatietaken niet merkbaar.
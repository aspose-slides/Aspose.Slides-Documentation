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
- schrijfbescherming
- PowerPoint-beveiliging
- presentatiebeveiliging
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
description: "Vergrendel en ontgrendel moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Bescherm uw presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Doorgaans kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als je alleen bepaalde gebruikers je presentatie wilt laten wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen wijzigen, aanpassen of onderdelen van je presentatie kopiëren (tenzij ze het wachtwoord geven). 

  Echter, in dit geval kan een gebruiker, zelfs zonder het wachtwoord, je document openen en bekijken. In deze alleen‑lezen‑modus kan de gebruiker de inhoud of zaken—hyperlinks, animaties, effecten en andere—in je presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je alleen bepaalde gebruikers je presentatie wilt laten openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van je presentatie kunnen bekijken (tenzij ze het wachtwoord geven).

  Technisch voorkomt de openingsbeperking ook dat gebruikers je presentatie kunnen wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigingen aanbrengen. 
  
  **Opmerking** dat wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentatiebestand wordt versleuteld.

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT - Microsoft PowerPoint‑presentatie 
- ODP - OpenDocument‑presentatie 
- OTP - OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides maakt het mogelijk wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides maakt het mogelijk andere taken uit te voeren die verband houden met wachtwoordbeveiliging en versleuteling op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie wachtwoordbeveiligd is.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet de gebruiker het wachtwoord invoeren. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [IProtectionManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

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

Je kunt een markering toevoegen met de tekst “Niet aanpassen” aan een presentatie. Zo kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbescherming de presentatie niet versleutelt. Daarom kunnen gebruikers — als ze dat willen — de presentatie aanpassen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam opslaan. 

Om schrijfbescherming in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) methode gebruiken. Deze voorbeeldcode laat zien hoe je schrijfbescherming voor een presentatie instelt:

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

Aspose.Slides maakt het mogelijk een versleuteld bestand te laden door het wachtwoord te verstrekken. Om een presentatie te ontsleutelen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) methode aanroepen zonder parameters. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // werk met ontsleutelde presentatie
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Versleuteling van een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling van een presentatie verwijdert:

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

Je kunt met Aspose.Slides de schrijfbescherming van een presentatiedossier verwijderen. Op deze manier mogen gebruikers aanpassen zoals ze willen — en krijgen ze geen waarschuwingen bij het uitvoeren van dergelijke bewerkingen.

Je kunt de schrijfbescherming van een presentatie verwijderen via de [removeWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie verwijdert:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **De eigenschappen van een versleutelde presentatie ophalen**

Doorgaans vinden gebruikers het moeilijk om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie met een wachtwoord kunt beveiligen en toch de mogelijkheid behoudt voor gebruikers om de eigenschappen van die presentatie te benaderen.

**Opmerking** dat wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie standaard ook met een wachtwoord worden beveiligd. Maar als je de eigenschappen van de presentatie toegankelijk wilt maken (zelfs nadat de presentatie is versleuteld), stelt Aspose.Slides je in staat om precies dat te doen. 

Wil je dat gebruikers de mogelijkheid behouden om de eigenschappen van een door jou versleutelde presentatie te bekijken, dan kun je de [encryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) eigenschap instellen op `true`. Deze voorbeeldcode laat zien hoe je een presentatie versleutelt én gebruikers toch toegang geeft tot de documenteigenschappen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Controleren of een presentatie wachtwoordbeveiligd is**

Voordat je een presentatie laadt, wil je misschien controleren of de presentatie niet met een wachtwoord is beveiligd. Op deze manier kun je fouten en soortgelijke problemen vermijden die optreden wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze Java‑code laat zien hoe je een presentatie kunt onderzoeken om te bepalen of deze wachtwoordbeveiligd is (zonder de presentatie zelf te laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie versleuteld is. Om deze taak uit te voeren kun je de [isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is en `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie schrijfbeschermd is. Om deze taak uit te voeren kun je de [isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) eigenschap gebruiken, die `true` retourneert als de presentatie schrijfbeschermd is en `false` als dit niet het geval is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeschermd is:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt**

Je wilt misschien controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // controleer of "pass" overeenkomt met
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Het retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert het `false`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog niveau van gegevensbeveiliging voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen een presentatie te openen?**

Er wordt een uitzondering gegooid als een onjuist wachtwoord wordt gebruikt, waarmee je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoordbeveiligde presentaties?**

Het versleutel‑ en ontsleutelingsproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is deze performance‑impact minimaal en heeft ze geen significante invloed op de totale verwerkingstijd van je presentatietaken.
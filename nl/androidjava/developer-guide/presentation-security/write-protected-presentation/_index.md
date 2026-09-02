---
title: Write‑protect presentaties op Android
linktitle: Write‑protectie
type: docs
weight: 25
url: /nl/androidjava/write-protected-presentation/
keywords:
- schrijfbescherming
- Schrijfbeveiliging PowerPoint
- wachtwoord om te wijzigen
- presentatiebewerking beperken
- schrijfbescherming verwijderen
- wijzigingswachtwoord valideren
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Instellen, detecteren, valideren en verwijderen van write‑protectie wachtwoorden in PowerPoint PPT‑ en PPTX‑presentaties met Aspose.Slides voor Android via Java."
---
## **Inleiding**

Een write‑protection‑wachtwoord beperkt het wijzigen van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een write‑protected presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de applicatie kunnen ze ook de inhoud bewerken en opslaan onder een andere naam, dus write‑protection mag niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een opening‑wachtwoord dient een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Om een presentatie te versleutelen of een opening‑wachtwoord te valideren, zie [Password-Protect Presentations](/slides/nl/androidjava/password-protected-presentation/).

De werkwijzen in dit artikel zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan naar PPT, gebruik de `.ppt`‑extensie en het overeenkomstige PPT‑opslaan‑formaat.

## **Write‑protectie instellen op een presentatie**

Gebruik [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie behoudt de beschermingsinstelling.

Het volgende voorbeeld stelt write‑protectie in op een PPTX‑presentatie:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Write‑protected presentatie laden**

Omdat write‑protectie de inhoud van de presentatie niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beschermde presentatie te wijzigen.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Geef geen write‑protection wachtwoord door aan [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Die methode accepteert een opening‑wachtwoord voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, geef dan het opening‑wachtwoord door om deze te laden en verwerk het write‑protection wachtwoord apart.

## **Write‑protectie verwijderen van een presentatie**

Gebruik [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) om de wijzigingsbeperking te verwijderen, en sla vervolgens de presentatie op.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een presentatie write‑protected is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-instantie te maken, roep je [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) aan en inspecteer je [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). De methode gebruikt [NullableBool](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/nullablebool/) en retourneert `NullableBool.True` wanneer write‑protectie wordt gedetecteerd.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

De stream‑overload van [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) biedt dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Write‑protection wachtwoord valideren**

Gebruik [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) om een wijzigings‑wachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer write‑protectie aanwezig is.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) valideert alleen het write‑protection wachtwoord. Het valideert geen opening‑wachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Omgekeerd valideert [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) alleen een opening‑wachtwoord. Als een volledige presentatie al is geladen, biedt [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) de equivalente write‑protection controle via zijn protection manager.

Log in productie‑applicaties geen wachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en bewaar wachtwoorden in het geheugen alleen zolang als nodig.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties beveiligen met wachtwoord](/slides/nl/androidjava/password-protected-presentation/)
- [Alleen‑lezen presentaties](/slides/nl/androidjava/read-only-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt write‑protectie een presentatie?**

Nee. Het beperkt de modificatie, maar laat de presentatie‑inhoud beschikbaar voor het laden en bekijken.

**Is het write‑protection wachtwoord vereist om een presentatie te openen?**

Nee. Alleen een opening‑wachtwoord is vereist om versleutelde presentatiedata te laden.

**Kan een presentatie zowel een opening‑wachtwoord als een write‑protection wachtwoord hebben?**

Ja. Geef het opening‑wachtwoord via de laadopties op om de versleutelde presentatie te openen, en valideer het write‑protection wachtwoord apart wanneer autorisatie voor wijziging nodig is.
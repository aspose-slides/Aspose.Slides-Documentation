---
title: Licensiering
description: "Applicera en licensfil till Aspose.Slides för Node.js via .NET, se vilka begränsningar som gäller för utvärderingsversionen, och få en gratis 30-dagars tillfällig licens för testning."
type: docs
weight: 80
url: /sv/nodejs-net/licensing/
---
## **Översikt**

Aspose.Slides för Node.js via .NET är ett npm-paket för både utvärdering och produktion. Utan en licens kör det i utvärderingsläge. När du köper en licens, eller får en gratis 30-dagars tillfällig licens, applicerar du den med några rader kod, och utvärderingsbegränsningarna gäller inte längre.

{{% alert color="info" title="Note" %}}
Allmänna riktlinjer för hur man utvärderar, licensierar och köper Aspose‑produkter finns samlade i [Köpriktlinjer och FAQ](https://purchase.aspose.com/policies). Priserna finns på sidan [Prisinformation](https://purchase.aspose.com/pricing/slides/sv/family).
{{% /alert %}}

## **Begränsningar för utvärderingsversionen**

Utvärderingsversionen ger produktens fulla funktionalitet, med två begränsningar:

- **Vattenstämpel.** Varje bild i varje presentation som du sparar får en utvärderingsvattenstämpel: en låst textruta i mitten av bilden med texten "Evaluation only." Samma vattenstämpel läggs till i PDF-, XPS- och HTML‑exporter samt på bildfiler.
- **Avkortad text.** Text som din kod läser tillbaka från en textruta, ett stycke eller en delavsnitt kapas till de fem första tecknen, följt av meddelandet "... text has been truncated due to evaluation version limitation." Markdown- och HTML5‑exporter avkortas på samma sätt. Texten som din kod skriver sparas i sin helhet.

[Utvärdera Aspose.Slides](/slides/sv/nodejs-net/evaluate-aspose-slides/) beskriver båda begränsningarna i detalj och innehåller ett skript som visar dem.

{{% alert color="success" title="Tip" %}}
För att testa Aspose.Slides utan utvärderingsbegränsningarna, begär en gratis **30‑dagars tillfällig licens**. Se [Hur får man en tillfällig licens?](https://purchase.aspose.com/temporary-license) för detaljer.
{{% /alert %}}

## **Om licensen**

Licensen är en rentext‑XML‑fil som innehåller detaljer såsom produktnamn, antalet utvecklare den är licensierad för och abonnemangets utgångsdatum. Filen är digitalt signerad, så ändra den inte: även ett extra radbrytning av misstag gör den ogiltig.

## **Applicera en licens**

Applicera licensen med `setLicense`‑metoden i `License`‑klassen. Anropa den en gång per process, innan du skapar något `Presentation`‑objekt. Att anropa den igen gör ingen skada, men upprepar arbete som redan utförts.

Följande skript applicerar en licens från en fil med namn `Aspose.Slides.lic`. Byt ut namnet mot namnet eller den fullständiga sökvägen till din licensfil; filen kan ha vilket namn som helst.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Ett filnamn eller en relativ sökväg löses mot den aktuella mappen, den du kör `node` från. Ha licensfilen i din projektmapp och kör dina skript därifrån, eller ange den fullständiga sökvägen.

Om filen inte kan hittas, eller inte är en giltig licens, kastar `setLicense` ett fel, och Aspose.Slides förblir i utvärderingsläge. Skriptet fångar felet och skriver ut dess meddelande. För en saknad fil börjar meddelandet med `License "Aspose.Slides.lic" doesn't exist or access is restricted.` och listar alla platser som söktes.

I detta paket appliceras en licens enbart från en fil. `License` accepterar inte en ström, och paketet exponerar inte metered‑licensiering. För klassen som paketet omsluter, se [License](https://reference.aspose.com/slides/sv/net/aspose.slides/license/) i Aspose.Slides för .NET API‑referensen.
---
title: Licencování
type: docs
weight: 80
url: /cs/nodejs-java/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- soubor licence
- hodnotící verze
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Node.js. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Úvod**

Někdy je pro dosažení nejlepších výsledků hodnocení potřeba praktický přístup. Z tohoto důvodu Aspose.Slides nabízí různé nákupní plány a také poskytuje bezplatnou zkušební verzi a 30denní dočasnou licenci pro hodnocení.

{{% alert color="info" title="Note" %}}
Všimněte si, že existuje řada obecných zásad a postupů, které vás vedou, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Zásady nákupu a FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Vyzkoušejte Aspose.Slides**
Aspose.Slides můžete snadno stáhnout pro hodnocení. Hodnotící balíček je stejný jako zakoupený balíček. Hodnotící verze se jednoduše stane licencovanou poté, co přidáte několik řádků kódu pro použití licence.

## **Omezení hodnotící verze**
Hodnotící verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, s dvěma omezeními:
* Přidá textové pole s vodotiskem hodnocení na každý snímek každé prezentace, kterou uloží.
* Text delší než pět znaků, který váš kód načte z prezentace, je oříznut na prvních pět znaků a následován `... text has been truncated due to evaluation version limitation.` Text o délce pět znaků nebo méně je vrácen beze změny a text, který váš kód zapíše, je uložen celý.

{{% alert color="info" title="Note" %}}
Pokud chcete testovat Aspose.Slides bez omezení hodnotící verze, můžete požádat o **30denní dočasnou licenci**. Další informace najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **O licenci**
Lze snadno stáhnout hodnotící verzi Aspose.Slides pro Node.js prostřednictvím Java z její [stahovací stránky](https://releases.aspose.com/slides/cs/nodejs-java/). Hodnotící verze má stejné funkce jako licencovaná verze, s výše popsanými omezeními. Navíc se hodnotící verze po zakoupení licence a přidání několika řádků kódu pro použití licence jednoduše stane licencovanou.

Licence je soubor ve formátu prostého textového XML, který obsahuje informace jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně. Soubor je digitálně podepsán, proto jej nechte nezměněný. I neúmyslné přidání dalšího konce řádku do obsahu souboru jej zneplatní.

Abyste se vyhnuli omezením spojeným s hodnotící verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licence je potřeba nastavit pouze jednou na aplikaci nebo proces.

{{% alert color="info" title="Note" %}}
Možná budete chtít zobrazit [Měřené licencování](/slides/cs/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Zakoupená licence**
Po zakoupení musíte použít soubor licence nebo stream.

{{% alert color="info" title="Note" %}}
Licence je potřeba nastavit:
* pouze jednou na proces
* před použitím jakýchkoli dalších tříd Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Informace o cenách najdete na stránce [Informace o cenách](https://purchase.aspose.com/pricing/slides/cs/family).
{{% /alert %}}

### **Nastavení licence v Aspose.Slides pro Node.js prostřednictvím Java**
Licence lze použít z následujících míst:
* Explicitní cesta
* Stream
* Jako měřená licence – nový licenční mechanismus

{{% alert color="info" title="Note" %}}
Použijte metodu **setLicense** k licencování komponenty.

I když více volání **setLicense** není škodlivých, představují zbytečnou zátěž zdrojů (procesoru).
{{% /alert %}}

#### **Použití licence ze souboru**
Tento útržek kódu slouží k nastavení souboru licence:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides běží v Java virtuálním stroji, který udržuje Node.js v chodu, takže proces ukončete explicitně.
process.exit(0);
```

Při volání metody setLicense by název licence měl být stejný jako název vašeho souboru licence. Například můžete změnit název souboru licence na "Aspose.Slides.lic.xml". Pak ve svém kódu musíte předat nový název licence (Aspose.Slides.lic.xml) metodě setLicense. Pokud soubor chybí nebo neobsahuje platnou licenci, [setLicense](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/license/setlicense/) vyvolá výjimku, která ukončí skript s chybou.

#### **Použití licence ze streamu**
Pro použití licence ze streamu předáte objekt [License](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/license/) a čitelný stream statické metodě [setLicenseFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/license/setlicense/). Stream je čten asynchronně a callback obdrží chybu, pokud stream neobsahuje platnou licenci:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides běží v Java virtuálním stroji, který udržuje Node.js v chodu, takže proces ukončete explicitně.
    process.exit(0);
});
```

Licence je aplikována, jakmile je celý stream přečten, těsně před spuštěním callbacku, takže další práci s Aspose.Slides zahajte z callbacku.

Obě ukázky volají `process.exit(0)`, když skončí, protože Java virtuální stroj, který spouští Aspose.Slides, udržuje Node.js v běhu. V aplikaci pokračujte svým kódem Aspose.Slides místo ukončení procesu.

## **Časté dotazy**

### Mohu použít licenci v zcela offline prostředí (bez přístupu k internetu)?
Ano. Ověření licence probíhá lokálně pomocí souboru licence; není vyžadováno žádné internetové připojení.

### Co se stane po vypršení jednoletého předplatného? Přestane knihovna fungovat?
Ne. Licence je trvalá: můžete nadále používat verze vydané před datem ukončení vašeho předplatného; jen nebudete mít nárok používat novější verze bez obnovení.
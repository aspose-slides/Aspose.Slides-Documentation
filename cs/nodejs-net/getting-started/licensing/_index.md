---
title: Licencování
description: "Aspose.Slides pro Node.js přes .NET poskytuje různé plány nákupu nebo nabízí bezplatnou zkušební verzi a 30denní dočasnou licenci pro vyhodnocení pomocí licenčních a předplatných zásad."
type: docs
weight: 80
url: /cs/nodejs-net/licensing/
---
Někdy je pro dosažení nejlepších hodnotících výsledků potřeba praktický přístup. Z tohoto důvodu Aspose.Slides nabízí různé nákupní plány a také poskytuje bezplatnou zkušební verzi a 30denní dočasnou licenci pro hodnocení.

{{% alert color="primary" %}}
Všimněte si, že existuje řada obecných zásad a postupů, které vás provádějí, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Zásady nákupu a FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Testovat Aspose.Slides**
Aspose.Slides můžete snadno stáhnout pro hodnocení. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou po přidání několika řádků kódu k aplikaci licence. 

## **Omezení evaluační verze**
Evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkcionalitu produktu, ale při otevření a uložení vloží evaluační vodoznak na horní část dokumentu. Také jste omezeni na jeden snímek při extrahování textu z prezentačních snímků.

{{% alert color="primary" %}} 
Pokud chcete testovat Aspose.Slides bez omezení evaluační verze, můžete požádat o **30denní dočasnou licenci**. Další informace najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **O licenci**
Evaluační verzi Aspose.Slides pro Node.js přes .NET si můžete snadno stáhnout z [download page](https://releases.aspose.com/slides/cs/nodejs-net/). Evaluační verze poskytuje naprosto **stejné funkce** jako licencovaná verze Aspose.Slides. Navíc se evaluační verze jednoduše stane licencovanou po zakoupení licence a přidání několika řádků kódu k aplikaci licence.

Licence je textový soubor XML, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně. Soubor je digitálně podepsán, takže jej neměňte. I neúmyslné přidání dalšího řádku do obsahu souboru jej zneplatní.

Aby se předešlo omezením spojeným s evaluační verzí, je třeba nastavit licenci před použitím **Aspose.Slides**. Licence je potřeba nastavit pouze jednou na aplikaci nebo proces.

## Zakoupená licence

Po zakoupení musíte aplikovat soubor licence nebo proud. 

{{% alert color="primary" %}}
Musíte nastavit licenci:
* pouze jednou na doménu aplikace
* před použitím jakýchkoli dalších tříd Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Informace o cenách najdete na stránce [“Pricing Information”](https://purchase.aspose.com/pricing/slides/cs/family).
{{% /alert %}}

### **Nastavení licence v Aspose.Slides pro Node.js přes .NET**
Licence lze aplikovat z těchto míst:

* Explicitní cesta
* Proud
* Jako měřená licence – nový licenční mechanismus

{{% alert color="primary" %}}
Použijte metodu **setLicense** k licencování komponenty.

I když více volání **setLicense** není škodlivých, jsou zbytečnou spotřebou zdrojů (procesoru).
{{% /alert %}}

{{% alert color="warning" %}}
Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

#### **Aplikace licence pomocí souboru**
Tento úryvek kódu slouží k nastavení souboru licence:

**Node.js**

```javascript
// Importujte modul Aspose.Slides pro manipulaci se soubory PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Tato funkce nastavuje knihovnu Aspose.Slides s licencí
function setupAsposeSlidesLicense() {
	
    // Inicializujte třídu License z modulu Aspose.Slides
    var license = new asposeSlides.License();
    
    // Použijte licenci ze souboru
    // Nahraďte "your_license_file.lic" cestou k vašemu skutečnému licenčnímu souboru
    license.setLicense("your_license_file.lic");
}

// Spusťte funkci pro nastavení licence pro Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Při volání metody setLicense by měl být název licence shodný s názvem vašeho licenčního souboru. Například můžete změnit název licenčního souboru na "Aspose.Slides.lic.xml". Pak ve svém kódu musíte předat nový název licence (Aspose.Slides.lic.xml) metodě setLicense.
{{% /alert %}}
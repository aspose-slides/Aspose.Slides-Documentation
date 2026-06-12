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
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Node.js. Zajistěte nepřetržitý přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Úvod**

Někdy může být pro dosažení nejlepších výsledků hodnocení potřeba praktický přístup. Z tohoto důvodu Aspose.Slides nabízí různé nákupní plány a také poskytuje bezplatnou zkušební verzi a 30‑denní dočasnou licenci pro hodnocení.

{{% alert color="primary" %}}

Všimněte si, že existuje řada obecných zásad a postupů, které vás provádějí, jak hodnotit, řádně licencovat a nakupovat naše produkty. Najdete je v sekci ["Zásady nákupu a FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Vyzkoušet Aspose.Slides**
Snadno si můžete stáhnout Aspose.Slides pro hodnocení. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše licencuje po přidání několika řádků kódu, který licenci použije.

## **Omezení evaluační verze**
Evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, ale při otevření a uložení přidává do horní části dokumentu vodotisk „evaluation“. Při extrahování textu z prezentací jste také omezeni na jeden snímek.

{{% alert color="primary" %}} 

Pokud chcete testovat Aspose.Slides bez omezení evaluační verze, můžete požádat o **30 denní dočasnou licenci**. Další informace najdete v [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **O licenci**
Snadno si můžete stáhnout evaluační verzi Aspose.Slides pro Node.js přes Java z její [stránky ke stažení](https://releases.aspose.com/slides/cs/nodejs-java/). Evaluační verze poskytuje naprosto **stejné možnosti** jako licencovaná verze Aspose.Slides. Navíc se po zakoupení licence a přidání několika řádků kódu licence automaticky aktivuje.

Licence je prostý textový XML soubor, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence platná, datum vypršení předplatného a další. Soubor je digitálně podepsán, proto jej neupravujte. I jen náhodné přidání prázdného řádku do obsahu souboru jej zneplatní.

Abyste se vyhnuli omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Nastavit licenci je potřeba pouze jednou na aplikaci nebo proces.

{{% alert color="primary" %}} 

Můžete si také přečíst [Metered Licensing](https://docs.aspose.com/slides/cs/nodejs-java/metered-licensing/).

{{% /alert %}} 

## **Zakoupená licence**

Po zakoupení je potřeba použít soubor licence nebo proud.

{{% alert color="primary" %}}

Musíte nastavit licenci:
* jen jednou na doménu aplikace
* před použitím jakékoli jiné třídy Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Informace o cenách najdete na stránce [“Pricing Information”](https://purchase.aspose.com/pricing/slides/cs/family).

{{% /alert %}}

### **Nastavení licence v Aspose.Slides pro Node.js přes Java**

Licence lze použít z těchto míst:

* Explicitní cesta
* Proud
* Jako Metered License – nový licenční mechanismus

{{% alert color="primary" %}}

Použijte metodu **setLicense** pro licencování komponenty.

I když volání **setLicense** vícekrát neškodí, je zbytečnou zátěží (procesoru).

{{% /alert %}}

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 a novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

#### **Použití licence ze souboru**

Tento úryvek kódu slouží k nastavení souboru licence:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Při volání metody setLicense by měl být název licence stejný jako název vašeho souboru licence. Například můžete změnit název souboru licence na "Aspose.Slides.lic.xml". Pak ve svém kódu předáte nový název licence (Aspose.Slides.lic.xml) metodě setLicense.

#### **Použití licence z proudu**

Tento úryvek kódu slouží k aplikaci licence z proudu:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **Často kladené otázky**

**Mohu použít licenci v zcela offline prostředí (bez přístupu k internetu)?**

Ano. Ověřování licence probíhá lokálně pomocí souboru licence; není vyžadováno připojení k internetu.

**Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem ukončení předplatného; jen nebudete mít nárok na novější vydání bez obnovení.
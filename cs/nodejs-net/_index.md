---
title: Aspose.Slides pro Node.js přes .NET
second_title: Aspose.Slides pro Node.js
type: docs
weight: 47
url: /cs/nodejs-net/
keywords:
- dokumentace
- zpracování prezentací
- převod prezentací
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro Node.js přes .NET, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, licencování, referenci API a podporu."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides pro Node.js přes .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET je knihovna pro vytváření, čtení, úpravu a převod prezentací PowerPoint a OpenDocument v aplikacích Node.js, bez Microsoft PowerPoint nebo Office Automation. Spouští Aspose.Slides pro .NET přes most edge‑js, takže její JavaScript API odráží .NET API s názvy členů ve stylu camelCase.

Načítá a ukládá PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, TIFF, Markdownu a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÍNÁME</p>
<ul>
<li><a href="/slides/cs/nodejs-net/installation/">Instalace</a></li>
<li><a href="/slides/cs/nodejs-net/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/nodejs-net/developer-guide/">Průvodce vývojáře</a></li>
</ul>
<p>HODNOCENÍ</p>
<ul>
<li><a href="/slides/cs/nodejs-net/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/nodejs-net/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Budování s Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/nodejs-net/open-presentation/">Otevřít a uložit prezentaci</a></li>
<li><a href="/slides/cs/nodejs-net/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/nodejs-net/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/nodejs-net/manage-text/">Upravit text</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Reference .NET API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Poznámky k vydání</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Ke stažení</a></li>
</ul>
<p>PODPOŘA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum bezplatné podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora (helpdesk)</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Potřebujete Node.js 22 nebo 24 a .NET SDK 8 nebo novější; Linux rovněž vyžaduje několik systémových balíků. [Instalace](/slides/cs/nodejs-net/installation/) je vypisuje a platformy, na nichž bylo testováno. Vytvořte projekt, přidejte přepis, který npm říká, kterou verzi edge‑js nainstalovat, a nainstalujte balíček:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Jednou na stroj obnovte .NET balíčky, na kterých knihovna závisí. Uložte soubor `deps.csproj` z [Obnovit .NET závislosti](/slides/cs/nodejs-net/installation/#restore-the-net-dependencies) do složky `deps` uvnitř složky projektu a poté spusťte:

```sh
dotnet restore deps/deps.csproj
```

Uložte tento kód jako *hello.js* ve složce projektu:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Nová prezentace obsahuje jeden prázdný snímek.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozice a velikost jsou v bodech (1/72 palce): x, y, šířka, výška.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Uvolněte .NET objekt, který podporuje prezentaci.
    presentation.dispose();
}
```

Spusťte jej ze složky projektu:

```sh
node hello.js
```

Skript vypíše `Saved hello.pptx` a uloží *hello.pptx* s jedním snímkem, který obsahuje obdélník s textem. Bez licence má uložený soubor evaluační vodotisk – viz [Licencování](/slides/cs/nodejs-net/licensing/). Další způsoby, jak vytvořit a vyplnit prezentaci, najdete v [Vytvořit prezentaci](/slides/cs/nodejs-net/create-presentation/).
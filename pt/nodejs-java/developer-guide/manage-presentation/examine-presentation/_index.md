---
title: Recuperar e Atualizar Informações da Apresentação em JavaScript
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/nodejs-java/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando JavaScript para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Ele explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, talvez você queira descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

É possível verificar o formato de uma apresentação sem carregá‑la. Veja este código JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Obter propriedades da apresentação**

Este código JavaScript mostra como obter propriedades da apresentação (informações sobre a apresentação):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Talvez você queira ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Atualizar propriedades da apresentação**

Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Suponha que tenhamos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Os resultados da alteração das propriedades do documento são mostrados abaixo.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Apresentações protegidas por senha](/slides/pt/nodejs-java/password-protected-presentation/)
- [Apresentações protegidas contra gravação](/slides/pt/nodejs-java/write-protected-presentation/)

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por [informações de fontes incorporadas](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) no nível da apresentação e, em seguida, compare essas entradas com o conjunto de [fonts realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) para identificar quais fontes são críticas para a renderização.

**Como posso descobrir rapidamente se o arquivo tem slides ocultos e quantos?**

Percorra a [coleção de slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) e verifique o [sinalizador de visibilidade](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/gethidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [tamanho do slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslidesize/) e a orientação atuais com os padrões predefinidos; isso ajuda a antecipar o comportamento ao imprimir e exportar.

**Existe uma maneira rápida de verificar se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e observe se os dados são internos ou baseados em link, incluindo links quebrados.

**Como posso avaliar slides 'pesados' que podem atrasar a renderização ou a exportação em PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para identificar possíveis gargalos de desempenho.
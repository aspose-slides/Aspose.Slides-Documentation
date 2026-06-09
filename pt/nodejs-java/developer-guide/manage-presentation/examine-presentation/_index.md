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

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, talvez você queira descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

Você pode verificar o formato de uma apresentação sem carregá‑la. Veja este código JavaScript:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Obter propriedades da apresentação**

Este código JavaScript mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Você pode querer ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Atualizar propriedades da apresentação**

O Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Suponha que temos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```javascript
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

- [Verificando se uma apresentação está criptografada](https://docs.aspose.com/slides/pt/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma apresentação está protegida contra gravação (somente leitura)](https://docs.aspose.com/slides/pt/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma apresentação está protegida por senha antes de carregá‑la](https://docs.aspose.com/slides/pt/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a senha usada para proteger uma apresentação](https://docs.aspose.com/slides/pt/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por [informações de fonte incorporada](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) no nível da apresentação, depois compare essas entradas com o conjunto de [fontes realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) para identificar quais fontes são críticas para a renderização.

**Como posso saber rapidamente se o arquivo tem slides ocultos e quantos?**

Itere pela [coleção de slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) e inspecione a [marca de visibilidade](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/gethidden/) de cada slide.

**Posso detectar se tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [tamanho de slide atual](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslidesize/) e a orientação com os presets padrão; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e note se os dados são internos ou baseados em link, incluindo quaisquer links quebrados.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou a exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis gargalos de desempenho.
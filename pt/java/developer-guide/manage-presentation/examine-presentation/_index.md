---
title: Recuperar e Atualizar Informações da Apresentação em Java
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/java/examine-presentation/
keywords:
- formato da apresentação
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
- Java
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Java para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão Geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Ele explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o Formato de uma Apresentação**

Antes de trabalhar em uma apresentação, você pode querer descobrir em que formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

Você pode verificar o formato de uma apresentação sem carregá‑la. Veja este código Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obter Propriedades da Apresentação**

Este código Java mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

Você pode querer ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#DocumentProperties--).

## **Atualizar Propriedades da Apresentação**

O Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Vamos supor que temos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades de documento originais da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Os resultados da alteração das propriedades de documento são mostrados abaixo.

![Propriedades de documento alteradas da apresentação PowerPoint](output_properties.png)

## **Links Úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Verificando se uma Apresentação está Criptografada](https://docs.aspose.com/slides/pt/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma Apresentação está Protegida contra Escrita (somente‑leitura)](https://docs.aspose.com/slides/pt/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma Apresentação está Protegida por Senha Antes de Carregá‑la](https://docs.aspose.com/slides/pt/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a Senha Usada para Proteger uma Apresentação](https://docs.aspose.com/slides/pt/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Perguntas Frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por [informações de fontes incorporadas](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) no nível da apresentação, depois compare essas entradas com o conjunto de [fontes realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/#getFonts--) para identificar quais fontes são críticas para renderização.

**Como posso identificar rapidamente se o arquivo tem slides ocultos e quantos?**

Percorra a [coleção de slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/) e inspecione a [bandeira de visibilidade](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#getHidden--) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [tamanho de slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlideSize--) e a orientação atuais com os padrões predefinidos; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getDataSourceType--), e observe se os dados são internos ou baseados em links, incluindo quaisquer links quebrados.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou exportação para PDF?**

Para cada slide, conte a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis pontos críticos de desempenho.
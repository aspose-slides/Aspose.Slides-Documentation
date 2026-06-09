---
title: Recuperar e Atualizar Informações da Apresentação em PHP
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, você pode querer descobrir em qual formato (PPT, PPTX, ODP, entre outros) ela está no momento.

É possível verificar o formato de uma apresentação sem carregá‑la. Veja este código PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Obter propriedades da apresentação**

Este código PHP mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Você pode querer ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Atualizar propriedades da apresentação**

O Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Suponha que tenhamos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Os resultados da alteração das propriedades do documento são mostrados abaixo.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Verificando se uma apresentação está criptografada](https://docs.aspose.com/slides/pt/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma apresentação está protegida contra gravação (somente leitura)](https://docs.aspose.com/slides/pt/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma apresentação está protegida por senha antes de carregá‑la](https://docs.aspose.com/slides/pt/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a senha usada para proteger uma apresentação](https://docs.aspose.com/slides/pt/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure informações de [fonte incorporada](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getembeddedfonts/) no nível da apresentação e compare essas entradas com o conjunto de [fonts realmente usados no conteúdo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getfonts/) para identificar quais fontes são críticas para a renderização.

**Como posso identificar rapidamente se o arquivo contém slides ocultos e quantos?**

Itere através da [coleção de slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/) e inspecione a [bandeira de visibilidade](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/gethidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [tamanho de slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getslidesize/) e a orientação atuais com as predefinições padrão; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getdatasourcetype/) e observe se os dados são internos ou baseados em links, incluindo links quebrados.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis pontos críticos de desempenho.
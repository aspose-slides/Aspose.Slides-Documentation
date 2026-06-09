---
title: Gerenciar Porções de Texto em Apresentações Usando PHP
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/php-java/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Saiba como gerenciar porções de texto em apresentações PowerPoint usando Aspose.Slides para PHP via Java, aumentando o desempenho e a personalização."
---
## **Introdução**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

## **Obter coordenadas de uma porção de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/getcoordinates/) método foi adicionado à classe [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) que permite recuperar as coordenadas do início da porção.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Reconfigurando o contexto da apresentação
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/php-java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma Porção sobrescreve e o que é herdado do Parágrafo/TextFrame?**

Propriedades no nível da Porção têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/), o mecanismo a obtém do [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/); se também não estiver definida lá, a obtém do [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/theme/).

**O que acontece se a fonte especificada para uma Porção estiver ausente na máquina/servidor de destino?**

[Regras de substituição de fontes](/slides/pt/php-java/font-selection-sequence/) se aplicam. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que é importante para posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico para a Porção, independente do resto do parágrafo?**

Sim, cor, preenchimento e transparência do texto no nível da [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) podem diferir dos fragmentos vizinhos.
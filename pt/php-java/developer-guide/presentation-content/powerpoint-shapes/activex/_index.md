---
title: Gerenciar Controles ActiveX em Apresentações Usando PHP
linktitle: ActiveX
type: docs
weight: 80
url: /pt/php-java/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Saiba como o Aspose.Slides for PHP via Java utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, oferecendo aos desenvolvedores controle avançado sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. Aspose.Slides for PHP via Java permite adicionar e gerenciar controles ActiveX, mas eles são um pouco mais difíceis de manipular em comparação com formas de apresentação normais. Implementamos suporte para adicionar o controle Active Media Player no Aspose.Slides. Observe que os controles ActiveX não são formas; eles não fazem parte da [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/). Eles pertencem à [ControlCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/controlcollection/) separada. Neste tópico, mostraremos como trabalhar com eles.

## **Adicionar um Controle ActiveX Media Player a um Slide**
Para adicionar um controle ActiveX Media Player, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e gere uma instância de apresentação vazia.
1. Acesse o slide de destino em [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Adicione o controle ActiveX Media Player usando o método [addControl](https://reference.aspose.com/slides/pt/php-java/aspose.slides/controlcollection/addcontrol/) exposto por [ControlCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/controlcollection/).
1. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
1. Salve a apresentação como um arquivo PPTX.

Este código de exemplo, baseado nas etapas acima, demonstra como adicionar o Controle ActiveX Media Player a um slide:

```php
  # Criar instância de apresentação vazia
  $pres = new Presentation();
  try {
    # Adicionar o controle ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Acessar o controle ActiveX Media Player e definir o caminho do vídeo
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Salvar a apresentação
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificar um Controle ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 e versões mais recentes são equipados com componentes para gerenciar controles ActiveX. Você pode acessar o controle ActiveX já adicionado em sua apresentação e modificá‑lo ou excluí‑lo por meio de suas propriedades.

{{% /alert %}} 

Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação que contém controles ActiveX.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse os controles ActiveX no slide por meio da [ControlCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/controlcollection/).
1. Acesse o controle ActiveX TextBox1 usando o objeto [Control](https://reference.aspose.com/slides/pt/php-java/aspose.slides/control/).
1. Alterar as propriedades do controle ActiveX TextBox1, incluindo texto, fonte, altura da fonte e posição da caixa.
1. Acesse o segundo controle chamado CommandButton1.
1. Alterar a legenda do botão, a fonte e a posição.
1. Deslocar a posição das caixas dos controles ActiveX.
1. Gravar a apresentação modificada em um arquivo PPTX.

Este código de exemplo, baseado nas etapas acima, demonstra como gerenciar um controle ActiveX simples:

```php
  # Acessando a apresentação com controles ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Acessando o primeiro slide na apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # alterando texto da TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Alterando imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX,
      # então, às vezes, é aceitável deixar a imagem inalterada.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Alterando a legenda do botão
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Alterando substituta
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # movendo 100 pontos para baixo
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # removendo controles
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**O Aspose.Slides preserva os controles ActiveX ao ler e salvar novamente caso eles não possam ser executados na runtime Java?**

Sim. O Aspose.Slides trata‑os como parte da apresentação e pode ler/modificar suas propriedades e caixas; a execução dos controles em si não é necessária para preservá‑los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, media player), enquanto [OLE](/slides/pt/php-java/manage-ole/) refere‑se a objetos de aplicação incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; no entanto, eventos e macros são executados apenas no PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.
---
title: Instalação
type: docs
weight: 70
url: /pt/php-java/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Instale rapidamente o Aspose.Slides para PHP via Java. Guia passo a passo, requisitos do sistema e exemplos de código — comece a trabalhar com apresentações PowerPoint hoje!"
---
## **Visão geral**

Este artigo explica como instalar e configurar Aspose.Slides for PHP via Java. Ele cobre a configuração do ambiente necessária, o download da biblioteca via Packagist, a configuração do Apache Tomcat com PHP/Java Bridge e a execução de um exemplo para verificar a instalação.

## **Configurar ambiente**

1. Instale o PHP 7, adicione o caminho do PHP à variável de sistema `PATH` e defina `allow_url_include` como `On` no arquivo `php.ini`.
1. Instale o JRE 8. Defina a variável de ambiente `JAVA_HOME` para o caminho do JRE instalado.
1. Instale o Apache Tomcat 8.0.

## **Baixar Aspose.Slides for PHP via Java**

`packagist` é a maneira mais fácil de baixar [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides).

Para instalar o Aspose.Slides usando Packagist, execute este comando:
   ```bash
   composer require aspose/slides
   ```

## **Configurar Apache Tomcat**

1. Baixe o PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) em http://php-java-bridge.sourceforge.net/pjb/download.php e extraia o arquivo `JavaBridge.war` para a pasta `webapps` do Tomcat.
1. Inicie o serviço Apache Tomcat.
1. Baixe [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/pt/php-java) e extraia-o para a pasta `aspose.slides`. Copie o arquivo `jar/aspose-slides-x.x-php.jar` para a pasta `webapps\JavaBridge\WEB-INF\lib`. Se você estiver usando **PHP 8**, substitua o `Java.inc` original do PHP-Java Bridge pelo `Java.inc` do `Java.inc.php8.zip`.
1. Reinicie o serviço Apache Tomcat.
1. Execute `example.php` na pasta `aspose.slides` para rodar o exemplo com este comando:
   ```bash
   php example.php
   ```

## **FAQ**

**Como posso verificar se o Aspose.Slides foi integrado corretamente?**

Compile seu projeto, instancie uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) vazia e salve-a com um novo nome. Se o arquivo for criado sem exceções, a biblioteca foi integrada com sucesso.

**Como posso limitar o consumo de memória ao processar apresentações grandes?**

Aumente os limites de memória da JVM apenas tanto quanto for necessário e feche cada instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) em um bloco `finally` para liberar o cache imediatamente. Isso evita erros de falta de memória e mantém o uso geral de memória previsível durante operações em lote.

**Posso excluir formatos de exportação indesejados para reduzir o tamanho final do JAR?**

As versões atuais do Aspose.Slides são distribuídas como uma única biblioteca monolítica, portanto não é possível desativar exportadores específicos como PDF ou SVG no momento da compilação.
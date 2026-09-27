---
title: Instalação
type: docs
weight: 70
url: /pt/php-java/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- Linux
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Instale o Aspose.Slides for PHP via Java no Linux e Windows: configure o PHP, Java, Apache Tomcat e PHP/Java Bridge, adicione o pacote com o Composer e verifique a configuração com um script curto."
---
## **Visão geral**

Aspose.Slides for PHP via Java é executado em dois processos. Seu script PHP usa classes PHP que encaminham cada chamada através do PHP/Java Bridge para o Aspose.Slides, que roda em Java dentro do Apache Tomcat. Este artigo explica como configurar ambos os lados, instalar o pacote com o Composer e executar um pequeno script para verificar a instalação.

## **Pré-requisitos**

- **PHP 7.0 a 8.3**, com `allow_url_include = On` no `php.ini`. Seus scripts carregam a biblioteca cliente da ponte, `Java.inc`, do Tomcat via HTTP. No PHP 8.4 e posteriores, `Java.inc` falha com o erro "end() expects exactly 1 argument" sempre que a extensão `xml` do PHP está carregada, e as compilações Windows do PHP sempre a carregam.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 ou posterior.** Um JRE é suficiente.
- **Apache Tomcat 9.** O PHP/Java Bridge é baseado na API `javax.servlet`, que o Tomcat 10 e posteriores não fornecem, portanto a ponte não inicia nesses ambientes.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, sua versão mais recente. Seu aplicativo web, `JavaBridge.war`, é executado no Tomcat.

Este artigo executa o Tomcat e seus scripts PHP no mesmo computador. O Aspose.Slides abre e salva arquivos dentro do Tomcat, portanto todo caminho que seus scripts passarem para ele deve ser válido lá.

## **Instalação no Linux**

Esses comandos instalam tudo na sua pasta home no Ubuntu 24.04. Em outras distribuições, instale os mesmos pacotes com o gerenciador de pacotes da distribuição.

1. Instale PHP, Composer, Java e as ferramentas de download, depois ative `allow_url_include` para a linha de comando do PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Baixe o Apache Tomcat 9 e o PHP/Java Bridge, coloque o `JavaBridge.war` da ponte na pasta `webapps` do Tomcat e inicie o Tomcat. O Tomcat descompacta o arquivo WAR em `webapps/JavaBridge` ao iniciar:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Crie uma pasta de projeto e instale o Aspose.Slides for PHP via Java a partir do [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Pare o Tomcat, copie o arquivo JAR do Aspose.Slides do pacote para a pasta `WEB-INF/lib` da ponte, substitua o `Java.inc` da ponte pela versão PHP 8 do pacote e inicie o Tomcat novamente:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/pt/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/pt/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   No PHP 7, ignore a substituição do `Java.inc`. O Tomcat leva alguns segundos para iniciar e deve estar em execução sempre que seus scripts usarem o Aspose.Slides.

## **Instalação no Windows**

1. Instale o [PHP 8.3 para Windows](https://www.php.net/downloads.php?os=windows) e adicione sua pasta à variável de ambiente `PATH`. Copie `php.ini-production` para `php.ini` na mesma pasta. No `php.ini`, defina `allow_url_include = On` e descomente as linhas `extension_dir = "ext"`, `extension=openssl` e `extension=zip`. O Composer precisa do `openssl` para baixar pacotes e do `zip` para descompactá‑los, a menos que o 7‑Zip esteja instalado ou um comando `unzip` esteja no `PATH`.
2. Instale o [Composer](https://getcomposer.org/download/).
3. Instale o Java e defina a variável de ambiente `JAVA_HOME` apontando para sua pasta. O Tomcat não inicia sem ela.
4. No Prompt de Comando, baixe o Apache Tomcat 9 e o PHP/Java Bridge, coloque o `JavaBridge.war` da ponte na pasta `webapps` do Tomcat e inicie o Tomcat. Os scripts do Tomcat encontram o Tomcat através da variável `CATALINA_HOME`, portanto continue usando a mesma janela do Prompt de Comando nas próximas etapas. O Tomcat descompacta o arquivo WAR em `webapps\JavaBridge` ao iniciar:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Crie uma pasta de projeto e instale o Aspose.Slides for PHP via Java a partir do [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Pare o Tomcat, copie o arquivo JAR do Aspose.Slides do pacote para a pasta `WEB-INF\lib` da ponte, substitua o `Java.inc` da ponte pela versão PHP 8 do pacote e inicie o Tomcat novamente:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   No PHP 7, ignore a substituição do `Java.inc`. O Tomcat leva alguns segundos para iniciar e deve estar em execução sempre que seus scripts usarem o Aspose.Slides.

## **Verificar a instalação**

Salve este script como *hello.php* na pasta do projeto. Ele cria uma apresentação com uma caixa de texto e a salva ao lado do script:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Execute-o a partir da pasta do projeto:

```bash
php hello.php
```

O script grava *hello.pptx*, com um slide que contém a caixa de texto. Sem licença, o slide também apresenta uma marca d'água de avaliação; veja [Licensing](/slides/pt/php-java/licensing/).

O script inclui `aspose.slides.php` diretamente: o autoloader do Composer não pode carregar essas classes, porque todas estão definidas naquele único arquivo. Ele também passa um caminho absoluto para `save`, pois o Aspose.Slides roda dentro do Tomcat e resolve um caminho relativo em relação à pasta de trabalho do Tomcat, não à do seu script.

## **FAQ**

**Como posso verificar se o Aspose.Slides está integrado corretamente?**

Execute o script em [Verificar a instalação](#verify-the-installation). Se ele gerar *hello.pptx* sem erros, PHP, PHP/Java Bridge e Aspose.Slides estão funcionando juntos.

**Por que meu script para com "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

O PHP não conseguiu carregar `Java.inc` a partir do Tomcat. Se a mensagem anterior disser que o wrapper `http://` está desabilitado, defina `allow_url_include = On` no arquivo `php.ini` que a linha de comando do PHP utiliza; `php --ini` mostra qual arquivo é esse. Se disser "Connection refused", o Tomcat ainda não está em execução: inicie-o ou aguarde alguns segundos até que ele esteja pronto.

**Como posso limitar o consumo de memória ao processar apresentações grandes?**

Aumente os limites de memória da JVM apenas o suficiente, e feche cada instância de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) em um bloco `finally` para liberar o cache rapidamente. Isso evita erros de falta de memória e mantém o uso geral de memória previsível durante operações em lote.

**Posso excluir formatos de exportação indesejados para reduzir o tamanho final do JAR?**

As versões atuais do Aspose.Slides são distribuídas como uma única biblioteca monolítica, portanto não é possível desabilitar exportadores específicos como PDF ou SVG durante a compilação.
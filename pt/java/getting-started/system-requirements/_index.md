---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/java/system-requirements/
keywords:
- requisitos do sistema
- plataformas suportadas
- versões Java
- JDK
- JRE
- fontconfig
- fontes
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Verifique o que o Aspose.Slides for Java necessita antes de instalá-lo: as versões Java suportadas e os sistemas operacionais, além da biblioteca de fontes e das fontes que o Linux requer."
---
## **Introdução**

Aspose.Slides for Java é uma biblioteca independente: não necessita do Microsoft PowerPoint ou do Microsoft Office. É um único arquivo JAR, publicado no repositório Maven da Aspose. O arquivo JAR contém apenas classes e recursos Java, sem bibliotecas nativas, e não declara dependências de outras bibliotecas. Portanto, o mesmo arquivo funciona em qualquer sistema operacional e processador para o qual esteja disponível um runtime Java compatível.

Este artigo lista as versões Java suportadas e os sistemas operacionais, bem como a biblioteca de fontes e fontes que o Linux necessita, e termina com um pequeno programa que verifica sua configuração. Para adicionar a biblioteca a um projeto, veja [Instalação](/slides/pt/java/installation/).

## **Versões Java Suportadas**

Aspose.Slides for Java funciona em Java 8 ou superior, com um JDK ou um JRE. Isso inclui as versões de suporte de longo prazo Java 8, 11, 17, 21 e 25, e versões posteriores como Java 26 e Java 27. O runtime Java pode ser de qualquer fornecedor, por exemplo Eclipse Temurin, Amazon Corretto, Oracle ou os pacotes OpenJDK de uma distribuição Linux.

Aspose.Slides não necessita de opções JVM, como `--add-opens`, em nenhuma dessas versões. No Java 11, a JVM imprime um aviso que começa com "WARNING: An illegal reflective access operation has occurred"; o aviso não afeta o resultado.

{{% alert color="warning" title="Warning" %}}
Java 6 e Java 7 estão obsoletos. Aspose.Slides for Java 26.9 ainda funciona neles, mas imprime um aviso de descontinuação. A partir da versão 26.10, Java 8 é o mínimo, e Java 6 e Java 7 não são mais suportados.
{{% /alert %}}

O projeto Maven e os comandos em [Instalação](/slides/pt/java/installation/) precisam de JDK 11 ou superior. Com Java 8, compile e execute seu programa como mostrado em [Verifique sua Configuração](#check-your-setup).

## **Sistemas Operacionais Suportados**

Como o arquivo JAR não contém código nativo, Aspose.Slides for Java funciona no Windows, Linux e macOS, em qualquer arquitetura de processador que o runtime Java suporte, como x64 e ARM64. O runtime Java é o único requisito no Windows. No Linux, o suporte a fontes do Java também precisa da biblioteca de fontes e das fontes descritas em [Linux](#linux).

## **Linux**

Aspose.Slides for Java organiza e desenha texto com o suporte a fontes do runtime Java. No Linux, esse suporte requer a biblioteca fontconfig e ao menos uma fonte instalada. Imagens de contêiner oficiais de distribuições Linux frequentemente não possuem nenhum dos dois. Sem eles, o primeiro exemplo em [Criar Apresentações](/slides/pt/java/create-presentation/) falha ao salvar a apresentação, deixa um arquivo vazio e relata este erro:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

As imagens de contêiner oficiais `eclipse-temurin`, para Ubuntu e Alpine Linux, já contêm fontconfig e as fontes DejaVu, portanto nada precisa ser instalado nelas. Em outros sistemas, instale os pacotes abaixo. Os comandos para Debian, Ubuntu e Red Hat utilizam `sudo`; em um Dockerfile, execute‑os em uma instrução `RUN` sem `sudo`. As fontes DejaVu são suficientes para o Aspose.Slides funcionar; as fontes usadas em suas apresentações são abordadas em [Fontes](#fonts).

### **Debian e Ubuntu**

Se você instalar Java a partir dos pacotes Debian ou Ubuntu com as configurações padrão do `apt-get`, como faz o comando em [Instalação](/slides/pt/java/installation/#linux), os pacotes Java também instalam a biblioteca fontconfig, as fontes DejaVu e a biblioteca HarfBuzz que esses pacotes Java precisam, e nada mais é necessário.

Com um runtime Java de outra fonte, como um arquivo do Eclipse Temurin, instale fontconfig e as fontes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Um Dockerfile costuma instalar os pacotes Java Debian ou Ubuntu, como `openjdk-21-jdk-headless` ou `default-jdk-headless`, usando a opção `--no-install-recommends`, que ignora todos os três. Instale fontconfig e as fontes DejaVu com o comando acima, e instale também o HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Sem o HarfBuzz, esses pacotes Java exibem `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, e a gravação falha com um `UnsatisfiedLinkError` que relata que `libharfbuzz.so.0` não pode ser aberto.

### **Red Hat Enterprise Linux**

Os pacotes `java-<version>-openjdk-headless` do Red Hat Enterprise Linux não instalam a biblioteca fontconfig. Instale-a juntamente com as fontes DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Os pacotes completos `java-<version>-openjdk` instalam fontconfig e fontes como dependências, e o mesmo vale para os pacotes Amazon Corretto do Amazon Linux 2023, como `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Em um Dockerfile baseado em Alpine Linux, instale fontconfig e as fontes DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Nas versões atuais do Alpine, `ttf-dejavu` instala o pacote `font-dejavu`. Instale Java com o pacote `openjdk<version>-jre` ou `openjdk<version>-jdk`, como `openjdk25-jdk`. Os pacotes `openjdk<version>-jre-headless` do Alpine Linux não contêm a biblioteca de fontes do Java, portanto, com eles o programa falha com `UnsatisfiedLinkError: no fontmanager in system library path`, mesmo quando as fontes estão instaladas.

### **Fontes**

Para que o texto seja renderizado com as fontes e métricas corretas, as fontes usadas em suas apresentações, ou substitutos adequados, devem estar instaladas no sistema ou carregadas por sua aplicação. Veja [Implantar Fontes](/slides/pt/java/deploy-fonts/), [Substituição de Fontes](/slides/pt/java/font-substitution/), e [Fontes Personalizadas](/slides/pt/java/custom-font/).

## **Verifique sua Configuração**

Para verificar se a biblioteca e seus requisitos estão presentes, execute um programa que salva uma apresentação e renderiza um slide em uma imagem. A gravação e a renderização utilizam o suporte a fontes do runtime Java, que é o que os requisitos do Linux acima fornecem.

Salve o código abaixo como *CheckSetup.java* na pasta que contém o arquivo JAR do Aspose.Slides. Para baixar o arquivo JAR, veja [Usar o Arquivo JAR sem Maven](/slides/pt/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Adicione um retângulo com texto ao primeiro slide e salve a apresentação.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Renderize o slide a um pixel por ponto e salve a imagem.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Com JDK 11 ou superior, execute o programa nessa pasta com o comando abaixo. Se o seu arquivo JAR tiver um nome diferente, altere o nome nos comandos.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Com Java 8, ou em um sistema que possui apenas um JRE, compile o programa com `javac` a partir de um JDK e então execute a classe compilada. No Linux e macOS, execute:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

No Windows, execute o mesmo comando `javac` e, em seguida, execute a classe usando ponto e vírgula como separador do classpath. Mantenha as aspas, para que o PowerShell não trate o ponto e vírgula como o fim do comando: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

O programa adiciona um retângulo com texto ao primeiro slide e salva a apresentação como *hello.pptx* com o método [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Em seguida, renderiza o slide com [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) e salva o resultado como *hello.png* com [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) no formato [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Os fatores de escala de 1 renderizam um pixel por ponto, de modo que o slide padrão de 720 × 540 pontos se torna uma imagem de 720 × 540 pixels, com o texto visível dentro do retângulo. Sem uma licença, ambos os arquivos também contêm uma marca d'água de avaliação; veja [Licenciamento](/slides/pt/java/licensing/). Se algum requisito estiver ausente, o programa interrompe com um dos erros descritos em [Linux](#linux).

## **Ferramentas de Desenvolvimento**

Você pode compilar aplicações que utilizam Aspose.Slides com qualquer JDK de uma versão Java suportada. Use o Apache Maven com o repositório Maven da Aspose, como descrito em [Instalação](/slides/pt/java/installation/), ou qualquer outra ferramenta de compilação que possa usar um repositório Maven. Você também pode adicionar o arquivo JAR ao classpath da sua IDE ou ferramenta de compilação manualmente.

## **FAQ**

**Preciso do Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário. Aspose.Slides é um motor independente para [criar](/slides/pt/java/create-presentation/), modificar, [converter](/slides/pt/java/convert-presentation/), e [renderizar](/slides/pt/java/convert-powerpoint-to-png/) apresentações.

**O Aspose.Slides for Java precisa de uma tela ou ambiente de desktop em um servidor Linux?**

Não. Aspose.Slides não precisa de um servidor X ou de uma tela, portanto funciona em servidores e em contêineres. No Linux, ele necessita apenas da biblioteca de fontes e das fontes descritas em [Linux](#linux).

**Quais fontes são necessárias para renderização correta?**

As fontes usadas na apresentação, ou [substitutos](/slides/pt/java/font-substitution/) adequados, devem estar disponíveis. No Linux e macOS, instale os pacotes de fontes que suas apresentações precisam para obter renderização consistente.

**Por que uma fonte personalizada é renderizada como substituta ou texto ausente no Linux?**

Se o arquivo de fonte possui entradas de tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, fazendo com que a fonte não seja resolvida. Usar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar um substituto consistente resolve o problema.
---
title: Instalar Aspose.Slides para Android via Java
type: docs
weight: 90
url: /pt/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação Aspose.Slides
- Gradle
- repositório Maven
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Adicione Aspose.Slides para Android via Java a um projeto Android Studio com Gradle a partir do repositório Maven da Aspose, ou adicione o arquivo JAR manualmente."
---
## **Visão geral**

Este artigo explica como adicionar Aspose.Slides for Android via Java a um projeto Android. A forma recomendada é deixar o Gradle baixar a biblioteca do repositório Maven da Aspose. Você também pode baixar o arquivo JAR e adicioná‑lo ao seu projeto manualmente.

A biblioteca não é publicada no Maven Central ou no repositório Maven do Google. Está disponível no próprio repositório da Aspose, como o artefato `aspose-slides` com o classificador `android.via.java`.

## **Instalar do repositório Maven da Aspose**

### **Etapa 1: Adicionar o repositório**

Novos projetos do Android Studio declaram seus repositórios no bloco `dependencyResolutionManagement` de *settings.gradle.kts*, e o Gradle rejeita repositórios que um arquivo de construção de módulo adiciona. Adicione a linha `maven` mostrada abaixo ao bloco `repositories` dentro desse bloco existente, ao invés de colar um segundo bloco `dependencyResolutionManagement`:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Etapa 2: Adicionar a dependência**

Adicione a biblioteca ao bloco `dependencies` do arquivo de construção do módulo app, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

A última parte das coordenadas, `android.via.java`, é o classificador que seleciona a compilação Android da biblioteca. Sem ele, o Gradle não consegue encontrar o artefato.

Em seguida, sincronize o projeto com os arquivos Gradle, para que o Gradle baixe a biblioteca.

### **Escolher uma versão**

Aspose.Slides for Android via Java não é compilado para todas as versões no repositório. Suas compilações são publicadas apenas para algumas versões do Aspose.Slides for Java, e uma versão sem compilação Android falha ao ser resolvida. Selecione uma versão listada na [página de download do Aspose.Slides for Android via Java](https://releases.aspose.com/slides/pt/androidjava/).

### **Scripts de compilação Groovy**

Se o seu projeto usa scripts de compilação Groovy, adicione a linha `maven` ao bloco `repositories` dentro do bloco `dependencyResolutionManagement` existente de *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

E adicione a dependência a *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Adicionar o arquivo JAR manualmente**

Se você não puder usar um repositório Maven, adicione o arquivo JAR ao seu projeto:

1. Baixe o arquivo JAR da pasta da versão no [repositório Maven da Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Para a versão 26.9, o arquivo é *aspose-slides-26.9-android.via.java.jar* na pasta *26.9*.
1. Copie o arquivo para a pasta *app/libs* do seu projeto. Crie a pasta se ela não existir.
1. Adicione o arquivo ao bloco `dependencies` de *app/build.gradle.kts*, então sincronize o projeto:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Criar sua primeira apresentação**

Após a sincronização do projeto, continue com [Criar apresentações](/slides/pt/androidjava/create-presentation/). Seu primeiro exemplo adiciona uma caixa de texto a um slide e salva a apresentação no armazenamento privado do seu aplicativo, que não requer permissão de armazenamento. Sem uma licença, Aspose.Slides adiciona uma marca d'água de avaliação a cada slide que salva; veja [Licenciamento](/slides/pt/androidjava/licensing/).

## **Versionamento**

Desde 2018, o versionamento do Aspose.Slides for Android via Java está em conformidade com o Aspose.Slides for Java. Compilações Android não são publicadas para todas as versões Java; veja [Escolher uma versão](#choose-a-version).

## **FAQ**

### Como posso verificar se o Aspose.Slides está integrado corretamente?

Compile seu projeto, instancie um [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) em branco e salve‑o com um novo nome. Se o arquivo for criado sem lançar exceções, a biblioteca foi integrada com sucesso.

### Como posso limitar o consumo de memória ao processar apresentações grandes?

Chame o método [dispose](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#dispose--) de cada instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) em um bloco `finally` para liberar seus recursos prontamente, e processe uma grande apresentação por vez. Isso ajuda a prevenir erros de falta de memória e mantém o uso geral de memória previsível durante operações em lote.

### Posso excluir formatos de exportação indesejados para reduzir o tamanho final do JAR?

As versões atuais do Aspose.Slides são distribuídas como uma única biblioteca monolítica, portanto não é possível desativar exportadores específicos como PDF ou SVG no momento da compilação.
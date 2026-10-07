---
title: Aspose.Slides para Android via Java
second_title: Aspose.Slides para Android
type: docs
weight: 40
url: /pt/androidjava/
keywords:
- documentação
- processamento de apresentação
- conversão de apresentação
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Comece aqui: adicione Aspose.Slides for Android via Java ao seu aplicativo, crie uma primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java é uma biblioteca de classes para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicativos Android, sem o Microsoft PowerPoint.

Ele carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes habilitadas para macro e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>COMECE</p>
<ul>
<li><a href="/slides/pt/androidjava/install-aspose-slides-for-android-via-java/">Instalação</a></li>
<li><a href="/slides/pt/androidjava/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/androidjava/getting-started/">Guia de início</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/androidjava/supported-file-formats/">Formatos de arquivos suportados</a></li>
<li><a href="/slides/pt/androidjava/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/androidjava/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construa com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/androidjava/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/androidjava/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/androidjava/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/androidjava/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/androidjava/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE SLIDES</p>
<ul>
<li><a href="/slides/pt/androidjava/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/androidjava/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/androidjava/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/androidjava/presentation-design/">Design de slide</a></li>
<li><a href="/slides/pt/androidjava/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/androidjava/examples/">Exemplos por elemento de slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Notas de versão</a></li>
<li><a href="/slides/pt/androidjava/known-issues/">Problemas conhecidos</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

## **Sua primeira apresentação**

A biblioteca vem do repositório Maven da Aspose. Novos projetos do Android Studio já possuem um bloco `dependencyResolutionManagement` em *settings.gradle.kts*. Adicione a linha `maven` mostrada abaixo ao bloco `repositories` dentro dele, em vez de colar um segundo bloco:

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

Em seguida, adicione a biblioteca a *app/build.gradle.kts* e sincronize o projeto:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Instalação](/slides/pt/androidjava/install-aspose-slides-for-android-via-java/) cobre scripts de build Groovy, o arquivo JAR manual e como escolher uma versão. O código para sua primeira apresentação está em [Criar apresentações](/slides/pt/androidjava/create-presentation/): ele adiciona uma caixa de texto a um slide e salva a apresentação no armazenamento do seu aplicativo. Essa amostra foi compilada e construída em um APK; não foi executada em um dispositivo. Sem uma licença, as apresentações salvas apresentam uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/androidjava/licensing/).
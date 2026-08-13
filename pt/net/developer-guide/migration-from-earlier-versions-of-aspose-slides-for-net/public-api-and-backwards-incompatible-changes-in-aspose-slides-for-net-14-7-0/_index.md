---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 14.7.0
linktitle: Aspose.Slides para .NET 14.7.0
type: docs
weight: 90
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Confira as atualizações da API pública e as alterações que quebram compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/), e outras alterações introduzidas com a API do Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Construtores e Elementos Removidos**
#### **Construtores de Alguns Subtipos de TransitionValueBase e TransitionValueFactory Removidos**
Os construtores de alguns subtipos de TransitionValueBase (especificamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) são inúteis na API pública e, por isso, foram removidos. 

A classe relacionada TransitionValueFactory e sua interface ITransitionValueFactory foram removidas pelo mesmo motivo.
#### **Elemento SoundAction Removido da Enumeração Aspose.Slides.SlideShow.TransitionType**
O elemento SoundAction era incorreto e não era usado. As configurações de som são definidas pelas propriedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classes e Interfaces Adicionadas**
#### **Classe FlyThroughTransition e Interface IFlyThroughTransition Adicionadas**
A classe Aspose.Slides.SlideShow.FlyThroughTransition (e sua interface Aspose.Slides.SlideShow.IFlyThroughTransition) está relacionada ao tipo de transição Flythrough suportado a partir desta versão.
#### **Classe GlitterTransition, Interface IGlitterTransition e Enumeração TransitionPattern Adicionadas**
A classe Aspose.Slides.SlideShow.GlitterTransition (e sua interface Aspose.Slides.SlideShow.IGlitterTransition) está relacionada ao tipo de transição Glitter suportado a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionPattern é usada nesta classe e especifica um padrão geométrico que se repete para preencher uma área maior.
#### **Classe LeftRightDirectionTransition, Interface ILeftRightDirectionTransition e Enumeração TransitionLeftRightDirectionType Adicionadas**
A classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (e sua interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) está relacionada aos tipos de transição Conveyor, Ferris, Flip, Gallery e Switch. Todos são suportados a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionLeftRightDirectionType é usada nesta classe e especifica uma direção, restrita aos valores left e right.
#### **Novos Elementos Adicionados à Enumeração Aspose.Slides.SlideShow.TransitionType**
A enumeração Aspose.Slides.SlideShow.TransitionType foi ampliada com novos elementos.

- Novos elementos relacionados a transições do PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- Novos elementos relacionados a transições do PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Classe RevealTransition e Interface IRevealTransition Adicionadas**
A classe Aspose.Slides.SlideShow.RevealTransition (e sua interface Aspose.Slides.SlideShow.IRevealTransition) está relacionada ao tipo de transição Reveal suportado a partir desta versão.
#### **Classe RippleTransition, Interface IRippleTransition e Enumeração TransitionCornerAndCenterDirectionType Adicionadas**
A classe Aspose.Slides.SlideShow.RippleTransition (e sua interface Aspose.Slides.SlideShow.IRippleTransition) está relacionada ao tipo de transição Ripple suportado a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType é usada nesta classe e especifica uma direção, restrita aos cantos e ao centro.
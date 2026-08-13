---
title: Aspose.Slides for Java 14.7.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공용 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for Java 14.7.0 API와 함께 도입된 모든 추가된 클래스, 메서드, 속성 등과 새로운 제한 사항 및 기타 변경 사항을 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
### **일부 TransitionValueBase 하위 유형의 생성자가 제거되었으며 TransitionValueFactory도 제거되었습니다**
TransitionValueBase 하위 유형(특히 CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition)의 생성자는 공개 API에서 사용할 수 없으므로 제거되었습니다. 관련 클래스 TransitionValueFactory와 그 인터페이스 ITransitionValueFactory도 동일한 이유로 제거되었습니다.
### **com.aspose.slides.TransitionType 열거형에서 SoundAction 요소가 제거되었습니다**
SoundAction 요소는 잘못되었으며 사용되지 않았습니다. 사운드 설정은 SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName 속성으로 정의됩니다.
### **FlyThroughTransition 클래스와 IFlyThroughTransition 인터페이스가 추가되었습니다**
컴포넌트 com.aspose.slides.FlyThroughTransition 클래스(및 그 인터페이스 com.aspose.slides.IFlyThroughTransition)는 이번 릴리스에서 지원되는 Flythrough 전환 유형과 관련됩니다.
### **GlitterTransition 클래스, IGlitterTransition 인터페이스 및 TransitionPattern 열거형이 추가되었습니다**
컴포넌트 com.aspose.slides.GlitterTransition 클래스(및 그 인터페이스 com.aspose.slides.IGlitterTransition)는 이번 릴리스에서 지원되는 Glitter 전환 유형과 관련됩니다. com.aspose.slides.TransitionPattern 열거형은 이 클래스에서 사용되며, 더 큰 영역을 채우기 위해 타일 형태로 배치되는 기하학적 패턴을 지정합니다.
### **LeftRightDirectionTransition 클래스, ILeftRightDirectionTransition 인터페이스 및 TransitionLeftRightDirectionType 열거형이 추가되었습니다**
컴포넌트 com.aspose.slides.LeftRightDirectionTransition 클래스(및 그 인터페이스 com.aspose.slides.ILeftRightDirectionTransition)는 이번 릴리스에서 지원되는 Switch, Flip, Ferris, Gallery, Conveyor 전환 유형과 관련됩니다. com.aspose.slides.TransitionLeftRightDirectionType 열거형은 이 클래스에서 사용되며, 방향을 left와 right 값으로 제한합니다.
### **com.aspose.slides.TransitionType 열거형에 새로운 요소가 추가되었습니다**
com.aspose.slides.TransitionType 열거형에 새로운 요소가 추가되었습니다. PowerPoint 2010의 새로운 전환과 관련된 요소: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. PowerPoint 2013의 새로운 전환과 관련된 요소: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition 클래스와 IRevealTransition 인터페이스가 추가되었습니다**
컴포넌트 com.aspose.slides.RevealTransition 클래스(및 그 인터페이스 com.aspose.slides.IRevealTransition)는 이번 릴리스에서 지원되는 Reveal 전환 유형과 관련됩니다. 컴포넌트 com.aspose.slides.RippleTransition 클래스, IRippleTransition 인터페이스 및 TransitionCornerAndCenterDirectionType 열거형이 추가되었습니다. 컴포넌트 com.aspose.slides.RippleTransition 클래스(및 그 인터페이스 com.aspose.slides.IRippleTransition)는 이번 릴리스에서 지원되는 Ripple 전환 유형과 관련됩니다. com.aspose.slides.TransitionCornerAndCenterDirectionType 열거형은 이 클래스에서 사용되며, 방향을 코너와 중심으로 제한합니다.
### **ShredTransition 클래스, IShredTransition 인터페이스 및 TransitionShredPattern 열거형이 추가되었습니다**
컴포넌트 com.aspose.slides.ShredTransition 클래스(및 그 인터페이스 com.aspose.slides.IShredTransition)는 이번 릴리스에서 지원되는 Shred 전환 유형과 관련됩니다. com.aspose.slides.TransitionShredPattern 열거형은 이 클래스에서 사용되며, 더 큰 영역을 채우기 위해 타일 형태로 배치되는 기하학적 형태를 지정합니다.